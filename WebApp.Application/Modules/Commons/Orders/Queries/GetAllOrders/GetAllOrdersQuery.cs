using System.Collections.Generic;
using MediatR;
using WebApp.Application.Modules.Commons.Orders.Dtos;

namespace WebApp.Application.Modules.Commons.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderDto>>
    {

    }
}
