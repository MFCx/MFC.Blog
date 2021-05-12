using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MFC.Blog.DTO.DTOs.BlogDtos;
using MFC.Blog.DTO.DTOs.CategoryDtos;
using MFC.Blog.DTO.DTOs.Comment;
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

            CreateMap<BlogUpdateModel, Entities.Concrete.Blog>();
            CreateMap<Entities.Concrete.Blog, BlogUpdateModel>();

            CreateMap<BlogAddModel, Entities.Concrete.Blog>();
            CreateMap<Entities.Concrete.Blog, BlogAddModel>();

            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>(); 

            CreateMap<Comment, CommentListDto>();
            CreateMap<CommentListDto, Comment>();

        }

    }
}
