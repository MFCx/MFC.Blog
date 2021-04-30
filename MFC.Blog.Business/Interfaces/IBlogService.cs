﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.Entities.Concrete;

namespace MFC.Blog.Business.Interfaces
{
    public interface IBlogService:IGenericService<Entities.Concrete.Blog>
    {
        Task<List<Entities.Concrete.Blog>> GetAllSortedByPostedTimeAsync();
    }
}