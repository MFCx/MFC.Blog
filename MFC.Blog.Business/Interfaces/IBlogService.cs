using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.DTO.DTOs.CategoryBlogDtos;
using MFC.Blog.Entities.Concrete;

namespace MFC.Blog.Business.Interfaces
{
    public interface IBlogService : IGenericService<Entities.Concrete.Blog>
    {
        Task<List<Entities.Concrete.Blog>> GetAllSortedByPostedTimeAsync();
        Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto);
        Task RemoveFromCategoryAsync(CategoryBlogDto categoryBlogDto);

        Task<List<Entities.Concrete.Blog>> GetAllByCategoryIdAsync(int categoryId);
        Task<List<Category>> GetCategoriesAsync(int blogId);
        Task<List<Entities.Concrete.Blog>> GetLastFiveAsync();

        Task<List<Entities.Concrete.Blog>> SearchAsync(string searchString);
    }
}
