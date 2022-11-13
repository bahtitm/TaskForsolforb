using System;
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
        public string Number { get; set; }
        /// <summary>
        /// Date(datetime2(7)) *редактируется* используется для фильтрации
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// ProviderId(int) *редактируется* используется для фильтрации
        /// </summary>
        /// 
        
        public int ProvideId { get; set; }

        
    }
}
