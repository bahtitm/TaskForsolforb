using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Modules.Commons.Regions.Commands.DeleteRegion;
using MediatR;
using WebApp.DataAccess.Interfaces;
using WebApp.DataAccess.Interfaces.Extensions;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.OrderItems.Commands.DeleteOrderItem
{
    public class DeleteOrderItemCommandHandler : AsyncRequestHandler<DeleteOrderItemCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteOrderItemCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await dbContext.FindByIdAsync<OrderItem>(request.Id, cancellationToken);
            dbContext.Set<OrderItem>().Remove(orderItem);
            await dbContext.SaveChangesAsync();
        }
    }
}
