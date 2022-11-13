using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Domain;

namespace WebApp.Infrastructure.Persistence.Configurations
{
    public class ProvideConfiguration : IEntityTypeConfiguration<Provide>
    {
        public void Configure(EntityTypeBuilder<Provide> builder)
        {

        }
    }
}
