using MediatR;

namespace WebApp.Application.Modules.Commons.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public int Id { get; set; }


    }
}
