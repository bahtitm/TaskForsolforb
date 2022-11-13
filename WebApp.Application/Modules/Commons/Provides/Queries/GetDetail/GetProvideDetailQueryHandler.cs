using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApp.Application.Modules.Commons.Provides.Dtos;
using WebApp.DataAccess.Interfaces;
using WebApp.DataAccess.Interfaces.Extensions;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.Provides.Queries.GetDetail
{
    public class GetProvideDetailQueryHandler : IRequestHandler<GetProvideDetailQuery, ProvideDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetProvideDetailQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ProvideDto> Handle(GetProvideDetailQuery request, CancellationToken cancellationToken)
        {
            var provide = await dbContext.FindByIdAsync<Provide>(request.Id);
            return mapper.Map<ProvideDto>(provide);
        }
    }
}
