using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MFC.Blog.DTO.DTOs.CategoryDtos;

namespace MFC.Blog.Business.ValidationRules.FluentValidation
{
    public class CategoryAddValidator:AbstractValidator<CategoryAddDto>
    {
        public CategoryAddValidator()
        {
            RuleFor(I=>I.Name)
                .NotEmpty().WithMessage("Kategory ismi boş geçilemez");
        }
    }
}
