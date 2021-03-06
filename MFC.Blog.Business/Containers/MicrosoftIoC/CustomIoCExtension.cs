using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MFC.Blog.Business.Concrete;
using MFC.Blog.Business.Interfaces;
using MFC.Blog.Business.Tools.JWTTools;
using MFC.Blog.Business.Tools.LogTool;
using MFC.Blog.Business.ValidationRules.FluentValidation;
using MFC.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using MFC.Blog.DataAccess.Interfaces;
using MFC.Blog.DTO.DTOs.AppUserDtos;
using MFC.Blog.DTO.DTOs.CategoryBlogDtos;
using MFC.Blog.DTO.DTOs.CategoryDtos;
using MFC.Blog.DTO.DTOs.Comment;
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
            

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentRepository>();


            services.AddScoped<IJwtService, JwtManager>();
            services.AddScoped<ICustomLogger, NLogAdapter>();

            //Her defasında yeni bir örnek alanması için AddTransient kullandık
            services.AddTransient<IValidator<AppUserLoginDto>,AppUserLoginValidator>(); ;
            services.AddTransient<IValidator<CategoryAddDto>,CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryBlogDto>,CategoryBlogValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>,CategoryUpdateValidator>();
            services.AddTransient<IValidator<CommentAddDto>, CommentAddValidator>();






        }

    }
}
