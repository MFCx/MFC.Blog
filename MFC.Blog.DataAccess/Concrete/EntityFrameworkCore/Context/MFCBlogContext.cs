using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.DataAccess.Mapping;
using MFC.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MFC.Blog.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class MFCBlogContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-BEAHAG3;database=MFCBlogDb ;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new BlogMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new CategoryBlogMap());
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Entities.Concrete.Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBlog> CategoryBlogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
