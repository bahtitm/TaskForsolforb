using System.Collections.Generic;
using MediatR;
using WebApp.Application.Modules.Commons.Provides.Dtos;

namespace WebApp.Application.Modules.Commons.Provides.Queries.GetAll
{
    public class GetAllProvideQuery : IRequest<IEnumerable<ProvideDto>>
    {
        public string Name { get; set; }

    }
}
