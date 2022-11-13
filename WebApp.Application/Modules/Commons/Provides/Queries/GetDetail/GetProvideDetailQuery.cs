using MediatR;
using WebApp.Application.Modules.Commons.Provides.Dtos;

namespace WebApp.Application.Modules.Commons.Provides.Queries.GetDetail
{
    public class GetProvideDetailQuery : IRequest<ProvideDto>
    {
        public int Id { get; set; }

        public GetProvideDetailQuery(int id)
        {
            Id = id;
        }
        public string Name { get; set; }
    }
}
