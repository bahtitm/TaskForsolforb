using MediatR;
using WebApp.Application.Modules.Commons.OrderItems.Dtos;

namespace WebApp.Application.Modules.Commons.OrderItems.Commands.CreateOrderItem
{
    public class CreateOrderItemCommand : IRequest<OrderItemDto>
    {

    }
}
