using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.DTO.Interfaces;

namespace MFC.Blog.DTO.DTOs.CategoryDtos
{
    public class CategoryUpdateDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
