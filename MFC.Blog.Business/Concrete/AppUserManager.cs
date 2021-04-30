using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MFC.Blog.Business.Interfaces;
using MFC.Blog.DataAccess.Interfaces;
using MFC.Blog.Entities.Concrete;

namespace MFC.Blog.Business.Concrete
{
    public class AppUserManager:GenericManager<AppUser>,IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;
        public AppUserManager(IGenericDal<AppUser> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
