using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using MFC.Blog.DataAccess.Interfaces;
using MFC.Blog.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MFC.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, IEntity, new()

    {
        public async Task<List<TEntity>> GetAllAsync()
        {
            using var context = new MFCBlogContext();

            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new MFCBlogContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            //En Son yazılanı en başta cıkarmak için 
            using var context = new MFCBlogContext();
            return await context.Set<TEntity>().OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TKey>> keySelector)
        {
            //En Son yazılanı en başta cıkarmak için filter ile  
            using var context = new MFCBlogContext();
            //keySelector herhangi bir tipte sıralama için verilmiş bir anahtar
            return await context.Set<TEntity>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new MFCBlogContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task AddAsync(TEntity entity)
        {
            using var context = new MFCBlogContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new MFCBlogContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            using var context = new MFCBlogContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            using var context = new MFCBlogContext();
            return await context.FindAsync<TEntity>(id);
        }
    
    }
}
