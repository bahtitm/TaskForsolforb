using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebApp.Application.Modules.Commons.Orders.Dtos;
using WebApp.DataAccess.Interfaces;
using WebApp.Domain;





namespace WebApp.Application.Modules.Commons.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateOrderCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

       
        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = mapper.Map<Order>(request);

            await dbContext.AddAsync(order);
            await dbContext.SaveChangesAsync();

            return mapper.Map<OrderDto>(order);
        }
    }
}
