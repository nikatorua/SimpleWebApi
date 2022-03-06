using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiTest6._0.Application.Interfaces;
using WebApiTest6._0.Domain.Basics;

namespace WebApiTest6._0.Persistance.Implementations
{
    internal abstract class Repository<TEntity> : IRepository<Guid, TEntity> where TEntity : BaseEntity
    {
        protected readonly DataContext _context;
        public Repository(DataContext context) => _context = context;


        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return await _context.SaveChangesAsync();
        }
        public virtual async Task<IEnumerable<TEntity>> ReadAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public virtual async Task<TEntity> ReadAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public virtual async Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateAsync2(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public virtual async Task<int> UpdateAsync(Guid id, TEntity entity)
        {
            var existing = _context.Set<TEntity>().Find(id);
            _context.Entry(existing).CurrentValues.SetValues(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(Guid id)
        {
            var item = await ReadAsync(id);
            _context.Set<TEntity>().Remove(item);
            return await _context.SaveChangesAsync();
        }
        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<bool> CheckAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().CountAsync(predicate);
        }

        public virtual object Test()
        {
            throw new NotImplementedException();
        }
    }
}
