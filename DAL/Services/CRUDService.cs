using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;

namespace DAL.Services
{
    public class CRUDService<T> : ICRUDService<T> where T : Entity
    {
        protected DbContext Context { get; }
        public CRUDService(DbContext context)
        {
            Context = context;
        }

        public async Task<int> CreateAsync(T entity)
        {
            var dbEntity = Context.Set<T>().Add(entity);
            await Context.SaveChangesAsync();
            return dbEntity.Entity.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            if (entity is null)
                return false;

            Context.Set<T>().Remove(entity);
            return (await Context.SaveChangesAsync()) == 1;
        }
        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await Context.Set<T>().AsNoTracking().ToArrayAsync();
        }

        public Task<T?> ReadAsync(int id)
        {
            //_context.Set<T>().FindAsync(id);   
            return Context.Set<T>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<bool> UpdateAsync(int id, T entity)
        {
            entity.Id = id;
            Context.Set<T>().Update(entity);
            return (await Context.SaveChangesAsync()) == 1;
        }
    }
}
