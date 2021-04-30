using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MFC.Blog.DTO.DTOs.BlogDtos;
using MFC.Blog.DTO.DTOs.CategoryDtos;
using MFC.Blog.Entities.Concrete;
using MFC.Blog.WebApi.Models;

namespace MFC.Blog.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<BlogListDto, Entities.Concrete.Blog>();
            CreateMap<Entities.Concrete.Blog, BlogListDto>();

            CreateMap<BlogAddModel, Entities.Concrete.Blog>();
            CreateMap<Entities.Concrete.Blog, BlogAddModel>();
            
            CreateMap<BlogUpdateModel, Entities.Concrete.Blog>();
            CreateMap<Entities.Concrete.Blog, BlogUpdateModel>();


            CreateMap<Category, CategoryAddDto>();
            CreateMap<CategoryAddDto, Category>();

            CreateMap<Category, CategoryListDto>();
            CreateMap<CategoryListDto, CategoryListDto>();

            CreateMap<Category, CategoryUpdateDto>();
            CreateMap<CategoryUpdateDto, CategoryUpdateDto>();


        }

    }
}
