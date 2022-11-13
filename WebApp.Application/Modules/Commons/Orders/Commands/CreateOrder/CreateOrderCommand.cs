using MediatR;
using WebApp.Application.Modules.Commons.Orders.Dtos;

namespace WebApp.Application.Modules.Commons.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<OrderDto>
    { 

    }
}
