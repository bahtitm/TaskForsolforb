using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DSEU.Application.Modules.Commons.TerritorialUnits.Commands.DeleteTerritorialUnit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApp.DataAccess.Interfaces;
using WebApp.DataAccess.Interfaces.Extensions;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.Provides.Commands.DeleteProvide
{
    public class DeleteProvideCommandHandler : AsyncRequestHandler<DeleteProvideCommand>
    {
        private readonly IApplicationDbContext dbContext;
        public DeleteProvideCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
        }
        protected override async Task Handle(DeleteProvideCommand request, CancellationToken cancellationToken)
        {
            var provide = await dbContext.FindByIdAsync<Provide>(request.Id);
            dbContext.Set<Provide>().Remove(provide);
            await dbContext.SaveChangesAsync();
        }


       
    }
}
