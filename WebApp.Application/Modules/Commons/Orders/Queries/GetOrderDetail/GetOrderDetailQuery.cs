using MediatR;
using WebApp.Application.Modules.Commons.Orders.Dtos;

namespace WebApp.Application.Modules.Commons.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery : IRequest<OrderDto>
    {
        public int Id { get; set; }

        public GetOrderDetailQuery(int id)
        {
            Id = id;
        }
    }
}
