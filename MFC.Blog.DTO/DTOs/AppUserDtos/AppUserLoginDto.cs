using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.DTO.Interfaces;

namespace MFC.Blog.DTO.DTOs.AppUserDtos
{
    public class AppUserLoginDto:IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
