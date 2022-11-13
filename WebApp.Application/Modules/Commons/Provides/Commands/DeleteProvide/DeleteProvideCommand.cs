using MediatR;

namespace DSEU.Application.Modules.Commons.TerritorialUnits.Commands.DeleteTerritorialUnit
{
    public class DeleteProvideCommand : IRequest
    {
        public int Id { get; }

        public DeleteProvideCommand(int id)
        {
            Id = id;
        }
    }
}