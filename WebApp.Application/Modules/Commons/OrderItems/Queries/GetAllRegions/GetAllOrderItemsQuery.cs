using System.Collections.Generic;
using MediatR;
using WebApp.Application.Modules.Commons.OrderItems.Dtos;

namespace WebApp.Application.Modules.Commons.OrderItems.Queries.GetAllRegions
{
    public class GetAllOrderItemsQuery : IRequest<IEnumerable<OrderItemDto>>
    {

    }
}
