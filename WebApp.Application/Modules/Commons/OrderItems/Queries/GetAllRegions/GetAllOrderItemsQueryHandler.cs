using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using WebApp.Application.Modules.Commons.OrderItems.Dtos;
using WebApp.DataAccess.Interfaces;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.OrderItems.Queries.GetAllRegions
{
    public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItemsQuery, IEnumerable<OrderItemDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllOrderItemsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<OrderItemDto>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<OrderItem>().ProjectTo<OrderItemDto>(mapper.ConfigurationProvider).ToList());
        }
    }
}
