using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebApp.Application.Modules.Commons.OrderItems.Dtos;
using WebApp.DataAccess.Interfaces;
using WebApp.DataAccess.Interfaces.Extensions;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.OrderItems.Commands.UpdateOrderItem
{
    public class UpdateOrderItemCommandHandler : AsyncRequestHandler<UpdateOrderItemCommand>
    {
        private readonly IMapper mapper;
        private readonly IApplicationDbContext dbContext;

        public UpdateOrderItemCommandHandler(IMapper mapper,IApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

       

        protected override async Task Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = await dbContext.FindByIdAsync<OrderItem>(request.Id);
            mapper.Map(request, orderItem);
            await dbContext.SaveChangesAsync(); 
        }
    }
}
