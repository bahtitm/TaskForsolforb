using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApp.Application.Modules.Commons.Orders.Dtos;
using WebApp.Application.Modules.Commons.Provides.Dtos;
using WebApp.DataAccess.Interfaces;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.Provides.Queries.GetAll
{
    public class GetAllProvideQueryHandler : IRequestHandler<GetAllProvideQuery, IEnumerable<ProvideDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        

        public GetAllProvideQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
           
        }
        public async Task<IEnumerable<ProvideDto>> Handle(GetAllProvideQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Provide>().ProjectTo<ProvideDto>(mapper.ConfigurationProvider).ToList());
        }
    }
}
