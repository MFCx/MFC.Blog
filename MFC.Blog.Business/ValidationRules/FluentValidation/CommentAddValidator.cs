using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MFC.Blog.DTO.DTOs.Comment;

namespace MFC.Blog.Business.ValidationRules.FluentValidation
{
    public class CommentAddValidator:AbstractValidator<CommentAddDto>
    {
        public CommentAddValidator()
        {
            RuleFor(I => I.AuthorName).NotEmpty().WithMessage("Yazar alanı boş geçilemez");
            RuleFor(I => I.AuthorEmail).NotEmpty().WithMessage("Yazar email boş geçilemez");
            RuleFor(I => I.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez");
            
        }
        
    }
}
