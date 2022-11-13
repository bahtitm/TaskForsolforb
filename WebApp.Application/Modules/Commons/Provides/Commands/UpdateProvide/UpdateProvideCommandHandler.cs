using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebApp.DataAccess.Interfaces;
using WebApp.DataAccess.Interfaces.Extensions;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.Provides.Commands.UpdateProvide
{
    public class UpdateProvideCommandHandler : AsyncRequestHandler<UpdateProvideCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
       

        public UpdateProvideCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            
        }

        protected override async Task Handle(UpdateProvideCommand request, CancellationToken cancellationToken)
        {
            var provide = await dbContext.FindByIdAsync<Provide>(request.Id);
            mapper.Map(request, provide);
            await dbContext.SaveChangesAsync();
        }
    }
}
