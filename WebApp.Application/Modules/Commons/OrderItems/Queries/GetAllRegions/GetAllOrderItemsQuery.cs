using System.Collections.Generic;
using MediatR;
using WebApp.Application.Modules.Commons.OrderItems.Dtos;

namespace WebApp.Application.Modules.Commons.OrderItems.Queries.GetAllRegions
{
    public class GetAllOrderItemsQuery : IRequest<IEnumerable<OrderItemDto>>
    {
        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public string Unit { get; set; }

       
        public int OrderId { get; set; }

    }
}
