using MediatR;

namespace WebApp.Application.Modules.Commons.Provides.Commands.UpdateProvide
{
    public class UpdateProvideCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
