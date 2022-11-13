using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Domain;

namespace WebApp.Infrastructure.Persistence.Configurations
{
    public class OrderItemConfiguraton : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
        }
    }
}
