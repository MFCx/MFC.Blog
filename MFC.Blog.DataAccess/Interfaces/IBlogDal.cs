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
        
    }
}
