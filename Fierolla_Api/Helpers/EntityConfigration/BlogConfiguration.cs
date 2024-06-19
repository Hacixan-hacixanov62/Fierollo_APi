using Fierolla_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fierolla_Api.Helpers.EntityConfigration
{
    public class BlogConfiguration:IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(m => m.Title).IsRequired();
            builder.Property(m => m.Description).IsRequired();
            builder.Property(m => m.Image).IsRequired();

        }
    }
}
