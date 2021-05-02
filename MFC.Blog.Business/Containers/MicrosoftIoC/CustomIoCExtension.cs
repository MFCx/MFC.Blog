using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.Business.Concrete;
using MFC.Blog.Business.Interfaces;
using MFC.Blog.Business.Tools.JWTTools;
using MFC.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using MFC.Blog.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MFC.Blog.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>),typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>),typeof(GenericManager<>));

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();


            services.AddScoped<IJwtService, JwtManager>();
        }

    }
}
