using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MFC.Blog.DataAccess.Mapping
{
    public class CommentMap:IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.AuthorName).HasMaxLength(100).IsRequired();
            builder.Property(I => I.AuthorEmail).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Description).HasMaxLength(400).IsRequired();

            builder.HasMany(I=>I.SubComments)
                .WithOne(I=>I.ParentComment).HasForeignKey(I=>I.ParentCommentId);
        }
    }
}
