using MediatR;
using WebApp.Application.Modules.Commons.Provides.Dtos;

namespace WebApp.Application.Modules.Commons.Provides.Commands.CreateProvide
{
    public class CreateProvideCommand : IRequest<ProvideDto>
    {
        public string Name { get; set; }

    }
}
