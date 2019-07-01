using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arq.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Arq.Data
{
    public class GenericRepository<TEntity> where TEntity : Entity
    {
        private ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return _context.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public Task<TEntity> GetByIdAsync(Guid id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes)
        {
            var queryable = _context.Set<TEntity>().AsQueryable();

            if (includes != null)
                queryable = includes(queryable);

            return queryable.SingleOrDefaultAsync(e => e.Id == id);
        }
    }
}