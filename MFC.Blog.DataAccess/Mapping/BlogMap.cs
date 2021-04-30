using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFC.Blog.DataAccess.Mapping
{
    public class BlogMap : IEntityTypeConfiguration<Entities.Concrete.Blog>
    {
    
        public void Configure(EntityTypeBuilder<Entities.Concrete.Blog> builder)
        {
            builder.HasKey(I=>I.Id);
            builder.Property(I=>I.Id).UseIdentityColumn();
            builder.Property(I=>I.Title).HasMaxLength(100).IsRequired();
            builder.Property(I=>I.ShortDescription).HasMaxLength(300).IsRequired();
            builder.Property(I=>I.ImagePath).HasMaxLength(300);
            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.HasMany(I=>I.Comments).WithOne(I=>I.Blog)
                .HasForeignKey(I=>I.BlogId);
            builder.HasMany(I => I.CategoryBlogs)
                .WithOne(I=>I.Blog).HasForeignKey(I=>I.BlogId);

        }
    }
}
