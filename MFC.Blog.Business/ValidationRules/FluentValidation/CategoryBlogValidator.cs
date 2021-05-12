using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MFC.Blog.DTO.DTOs.CategoryBlogDtos;

namespace MFC.Blog.Business.ValidationRules.FluentValidation
{
    public class CategoryBlogValidator:AbstractValidator<CategoryBlogDto>
    {
        public CategoryBlogValidator()
        {
            RuleFor(I => I.BlogId)
                .InclusiveBetween(0, int.MaxValue).WithMessage("Kategori alanı zorunludur.");
            RuleFor(I => I.BlogId)
                .InclusiveBetween(0, int.MaxValue).WithMessage("Blog alanı zorunludur. ");
        }
    }
}
