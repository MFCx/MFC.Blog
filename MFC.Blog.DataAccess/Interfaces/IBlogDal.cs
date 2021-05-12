using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.Entities.Concrete;

namespace MFC.Blog.DataAccess.Interfaces
{
    public interface IBlogDal:IGenericDal<Entities.Concrete.Blog>
    {
        Task<List<Entities.Concrete.Blog>> GetAllByCategoryIdAsync(int categoryId);
        Task<List<Category>> GetCategoriesAsync(int blogId);
        Task<List<Entities.Concrete.Blog>> GetLastFiveAsync();
     

    }
}
