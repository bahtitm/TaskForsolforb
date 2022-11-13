using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebApp.Application.Modules.Commons.Orders.Dtos;
using WebApp.DataAccess.Interfaces;
using WebApp.DataAccess.Interfaces.Extensions;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetOrderDetailQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var order = await dbContext.FindByIdAsync<Order>(request.Id);
            return mapper.Map<OrderDto>(order);
        }
    }
}
