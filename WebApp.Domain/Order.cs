using System;
using System.Collections.Generic;

namespace WebApp.Domain
{
    public class Order:BaseEntity
    {
        /// <summary>
        /// Number(nvarchar(max)) *редактируется* используется для фильтрации
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Date(datetime2(7)) *редактируется* используется для фильтрации
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// ProviderId(int) *редактируется* используется для фильтрации
        /// </summary>
        /// 
        public virtual Provide  Provide { get; set; }
        public int ProvideId { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }


    }
}