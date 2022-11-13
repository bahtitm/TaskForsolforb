namespace WebApp.Application.Modules.Commons.OrderItems.Dtos
{
    public class OrderItemDto
    {
        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public string Unit { get; set; }

       
        public int OrderId { get; set; }

    }
}
