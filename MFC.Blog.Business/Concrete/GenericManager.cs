using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.Business.Interfaces;
using MFC.Blog.DataAccess.Interfaces;
using MFC.Blog.Entities.Interfaces;

namespace MFC.Blog.Business.Concrete
{
    public class GenericManager<TEntity> :IGenericService<TEntity> where TEntity:class,IEntity,new()
    {
        private readonly IGenericDal<TEntity> _genericDal;

        public GenericManager(IGenericDal<TEntity> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
           return await _genericDal.GetAllAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
           return await _genericDal.GetAllAsync(filter);
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _genericDal.GetAllAsync(filter,keySelector);
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
           return await _genericDal.GetAllAsync(keySelector);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _genericDal.GetAsync(filter);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _genericDal.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _genericDal.UpdateAsync(entity);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await _genericDal.RemoveAsync(entity);
        }
    }
}
