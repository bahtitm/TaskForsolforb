using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApp.Application.Modules.Commons.OrderItems.Dtos;
using WebApp.DataAccess.Interfaces;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.OrderItems.Queries.GetOrderItemDetail
{
    public class GetOrderItemDetailQueryHandler : IRequestHandler<GetOrderItemDetailQuery, OrderItemDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetOrderItemDetailQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<OrderItemDto> Handle(GetOrderItemDetailQuery request, CancellationToken cancellationToken)
        {
            var orderItem = await dbContext.Set<OrderItem>().FirstOrDefaultAsync(p => p.Id == request.Id);
            return mapper.Map<OrderItemDto>(orderItem);
        }
    }
}
