namespace WebApp.Domain
{
    public class OrderItem : BaseEntity
    {
        //- OrderId(int)
        //- Name(nvarchar(max)) *редактируется* используется для фильтрации
        //- Quantity decimal (18, 3) *редактируется 
        //- Unit(nvarchar(max)) *редактируется* используется для фильтрации        
        
        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public string Unit { get; set; }

        public virtual Order Order { get; set; }
        public int OrderId { get; set; }

    }
}
