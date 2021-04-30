using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.DataAccess.Interfaces;
using MFC.Blog.Entities.Concrete;

namespace MFC.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryRepository:EfGenericRepository<Category>,ICategoryDal
    {
        
    }
}
