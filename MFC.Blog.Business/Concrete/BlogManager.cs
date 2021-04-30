using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MFC.Blog.Business.Interfaces;
using MFC.Blog.DataAccess.Interfaces;
using MFC.Blog.Entities.Concrete;

namespace MFC.Blog.Business.Concrete
{
    public class BlogManager:GenericManager<Entities.Concrete.Blog>,IBlogService
    {
        private readonly IGenericDal<Entities.Concrete.Blog> _genericDal;
        public BlogManager(IGenericDal<Entities.Concrete.Blog> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<List<Entities.Concrete.Blog>> GetAllSortedByPostedTimeAsync()
        {
            return await _genericDal.GetAllAsync(I=>I.PostedTime);
        }
    }
}
