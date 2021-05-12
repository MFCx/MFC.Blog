using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MFC.Blog.DTO.DTOs.CategoryDtos;

namespace MFC.Blog.Business.ValidationRules.FluentValidation
{
    public class CategoryUpdateValidator:AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(0, int.MaxValue).WithMessage("id alanı boş geçilemez");
            RuleFor(I => I.Name).NotNull().WithMessage("Kategori adı boş geçilemez");
        }
        
    }
}
