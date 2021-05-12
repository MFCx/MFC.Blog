using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MFC.Blog.DTO.DTOs.AppUserDtos;

namespace MFC.Blog.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginValidator:AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(I=>I.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilmez");
            RuleFor(I=>I.Password).NotEmpty().WithMessage("Şifre boş geçilmez");
        }
        
    }
}
