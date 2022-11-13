using MediatR;
using WebApp.Application.Modules.Commons.OrderItems.Dtos;

namespace WebApp.Application.Modules.Commons.OrderItems.Queries.GetOrderItemDetail
{
    public class GetOrderItemDetailQuery : IRequest<OrderItemDto>
    {
        public int Id { get; set; }

        public GetOrderItemDetailQuery(int id)
        {
            Id = id;
        }
    }
}
