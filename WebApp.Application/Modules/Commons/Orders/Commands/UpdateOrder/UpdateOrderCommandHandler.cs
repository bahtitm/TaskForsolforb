using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebApp.DataAccess.Interfaces;
using WebApp.DataAccess.Interfaces.Extensions;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : AsyncRequestHandler<UpdateOrderCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UpdateOrderCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await dbContext.FindByIdAsync<Order>(request.Id);
            mapper.Map(request,order);
            await dbContext.SaveChangesAsync();
        }
    }
}
