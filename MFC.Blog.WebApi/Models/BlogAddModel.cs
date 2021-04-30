using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MFC.Blog.WebApi.Models
{
    public class BlogAddModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
        //IFormFile AspNetCore nesnesi ve bağımlılık yaratıyor o yüzden bunu Dto değil Model olarak tanımladık.
        public int AppUserId { get; set; }

    }
}
