using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.DTO.Interfaces;

namespace MFC.Blog.DTO.DTOs.CategoryDtos
{
    public class CategoryAddDto:IDto
    {
        public string Name { get; set; }
    }
}
