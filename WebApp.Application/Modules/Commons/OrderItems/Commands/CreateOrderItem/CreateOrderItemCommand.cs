using MediatR;
using WebApp.Application.Modules.Commons.OrderItems.Dtos;

namespace WebApp.Application.Modules.Commons.OrderItems.Commands.CreateOrderItem
{
    public class CreateOrderItemCommand : IRequest<OrderItemDto>
    {
        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public string Unit { get; set; }

        
        public int OrderId { get; set; }

    }
}
