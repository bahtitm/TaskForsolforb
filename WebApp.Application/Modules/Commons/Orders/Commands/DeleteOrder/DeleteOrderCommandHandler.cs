using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApp.DataAccess.Interfaces;
using WebApp.DataAccess.Interfaces.Extensions;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : AsyncRequestHandler<DeleteOrderCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteOrderCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await dbContext.FindByIdAsync<Order>(request.Id);
            dbContext.Set<Order>().Remove(order);
            await dbContext.SaveChangesAsync();
        }
    }
}
