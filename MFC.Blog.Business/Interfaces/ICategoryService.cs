using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.Entities.Concrete;

namespace MFC.Blog.Business.Interfaces
{
    public interface ICategoryService:IGenericService<Category>
    {
        Task<List<Category>> GetAllSortedById();
        //Son eklenen en basa gelecek
    }
}
