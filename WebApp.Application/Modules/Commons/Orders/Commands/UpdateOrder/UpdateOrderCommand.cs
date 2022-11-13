using System;
using MediatR;

namespace WebApp.Application.Modules.Commons.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public int Id { get; set; }
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
