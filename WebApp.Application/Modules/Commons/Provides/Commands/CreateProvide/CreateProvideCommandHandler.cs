using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebApp.Application.Modules.Commons.Provides.Dtos;
using WebApp.DataAccess.Interfaces;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.Provides.Commands.CreateProvide
{
    public class CreateProvideCommandHandler : IRequestHandler<CreateProvideCommand, ProvideDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateProvideCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ProvideDto> Handle(CreateProvideCommand request, CancellationToken cancellationToken)
        {
            var provide = mapper.Map<Provide>(request);
            await dbContext.AddAsync(provide);
            await dbContext.SaveChangesAsync();
            return mapper.Map<ProvideDto>(provide);
        }
    }
}
