using Fierolla_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fierolla_Api.Helpers.EntityConfigration
{
    public class ProductConfigruation:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Price).IsRequired();
            builder.Property(m => m.Description).IsRequired();
            builder.Property(m => m.CategoryId).IsRequired();

        }
    }
}
