using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.Business.Interfaces;
using MFC.Blog.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MFC.Blog.WebApi.CustomFilters
{
    public class ValidId<TEntity>:IActionFilter
    where TEntity:class,IEntity,new()
    {
        private readonly IGenericService<TEntity> _genericService;

        public ValidId(IGenericService<TEntity> genericService)
        {
            _genericService = genericService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
             
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary=context.ActionArguments
                .FirstOrDefault(I => I.Key=="id");
            var id = int.Parse(dictionary.Value.ToString());
            var entity=_genericService.FindByIdAsync(id).Result;
            if (null==entity)
            {
                context.Result = new NotFoundObjectResult($"İlgili {id} degerine sahip nesne bulunamadı");
            }
        }
    }
}
