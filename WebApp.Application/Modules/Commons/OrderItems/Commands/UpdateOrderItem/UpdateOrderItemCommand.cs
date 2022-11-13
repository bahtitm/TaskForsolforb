using MediatR;
using WebApp.Application.Modules.Commons.OrderItems.Dtos;

namespace WebApp.Application.Modules.Commons.OrderItems.Commands.UpdateOrderItem
{
    public class UpdateOrderItemCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
