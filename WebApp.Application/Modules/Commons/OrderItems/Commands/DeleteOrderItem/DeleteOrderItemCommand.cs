using MediatR;

namespace DSEU.Application.Modules.Commons.Regions.Commands.DeleteRegion
{
    public class DeleteOrderItemCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteOrderItemCommand(int id)
        {
            Id = id;
        }
    }
}
