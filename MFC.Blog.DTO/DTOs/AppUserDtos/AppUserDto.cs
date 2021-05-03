using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.DTO.Interfaces;

namespace MFC.Blog.DTO.DTOs.AppUserDtos
{
    public class AppUserDto:IDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
