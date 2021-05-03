using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MFC.Blog.DataAccess.Interfaces;
using MFC.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MFC.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryRepository:EfGenericRepository<Category>,ICategoryDal
    {
        public async Task<List<Category>> GetAllWithCategoryBlogsAsync()
        {
            using var context = new MFCBlogContext();
            return await context.Categories.OrderByDescending(I => I.Id)
                .Include(I => I.CategoryBlogs).ToListAsync();
        }
    }
}
