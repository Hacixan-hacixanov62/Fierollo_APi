using Fierolla_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fierolla_Api.Helpers.EntityConfigration
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        }
    }
}
