using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebApp.Application.Modules.Commons.OrderItems.Dtos;
using WebApp.DataAccess.Interfaces;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.OrderItems.Commands.CreateOrderItem
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, OrderItemDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateOrderItemCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<OrderItemDto> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = mapper.Map<OrderItem>(request);

            await dbContext.AddAsync(orderItem);
            await dbContext.SaveChangesAsync();

            return mapper.Map<OrderItemDto>(orderItem);

        }
    }
}
