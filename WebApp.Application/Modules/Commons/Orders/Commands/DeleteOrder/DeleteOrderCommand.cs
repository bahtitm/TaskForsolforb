using MediatR;

namespace WebApp.Application.Modules.Commons.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteOrderCommand(int id)
        {
            Id = id;
        }
    }
}
