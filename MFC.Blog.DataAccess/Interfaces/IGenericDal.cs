using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.Entities.Interfaces;

namespace MFC.Blog.DataAccess.Interfaces
{
    public interface IGenericDal<TEntity> where TEntity : class,IEntity, new()

    {
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity,bool>>filter);

        Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter
            , Expression<Func<TEntity, TKey>> keySelector);
        Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector);
        Task<TEntity> GetAsync(Expression<Func<TEntity,bool>>filter);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(int id);

    }
}
