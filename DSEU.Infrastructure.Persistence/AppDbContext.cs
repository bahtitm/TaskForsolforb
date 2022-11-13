using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using WebApp.DataAccess.Interfaces;
using WebApp.Domain;

namespace WebApp.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IApplicationDbContext
    {
        private readonly IMediator mediator;
        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator) : base(options)
        {
            this.mediator = mediator;
        }

        

        public override EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
        {
            return base.Entry(entity);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return this.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task InvokeTransactionAsync(Func<Task> action, CancellationToken cancellationToken = default)
        {
            if (this.Database.CurrentTransaction != null)
            {
                await action();
                return;
            }

            using var transaction = await this.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await action();
                await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<T> InvokeTransactionAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken = default)
        {
            if (this.Database.CurrentTransaction != null)
            {
                return await action();
            }
            else
            {
                using var transaction = await this.Database.BeginTransactionAsync(cancellationToken);
                try
                {
                    var result = await action();
                    await transaction.CommitAsync(cancellationToken);
                    return result;
                }
                catch
                {

                    await transaction.RollbackAsync(cancellationToken);
                    throw;
                }
            }
        }

        async Task IApplicationDbContext.AddAsync<T>(T entity, CancellationToken cancellationToken)
        {
            await AddAsync(entity, cancellationToken);
        }

        void IApplicationDbContext.Add<T>(T entitiy)
        {
            Add(entitiy);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (mediator == null) return result;

            // dispatch events only if save was successful
            //var entitiesWithEvents = base.ChangeTracker.Entries<BaseEntity>()
            //    .Select(e => e.Entity)
            //    .Where(e => e.Events.Any())
            //    .ToArray();

            //foreach (var entity in entitiesWithEvents)
            //{
            //    var events = entity.Events.ToArray();
            //    entity.Events.Clear();
            //    foreach (var domainEvent in events)
            //    {
            //        await mediator.Publish(domainEvent).ConfigureAwait(false);
            //    }
            //}

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }

       
    }
}
