using Jazani.Domain.Cores.Models;
using Jazani.Domain.Cores.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Cores.Repositories
{
    public abstract class BaseRepository<T, ID> : IBaseRepository<T, ID> where T : CoreModel<ID>
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> _dbSet;
        protected BaseRepository(ApplicationDbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
            _dbContext = dbContext;
        }

        public virtual async Task<T> DisableAsync(ID id)
        {
            T? entity = await _dbSet.FindAsync(id);

            if (entity == null) throw new Exception("No se encontro informacion para el id: " + id);

            entity.State = false;
            _dbSet.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IReadOnlyList<T>> FindAllAsync()
        {
            return await _dbSet
                .Where(x => x.State == true)
                .ToListAsync();
        }

        public Task<T?> FindByIdAsync(ID id)
        {
            //return await _dbSet.FindAsync(id);

            throw new NotImplementedException();
        }

        public Task<T> SaveAsync(T entity)
        {
            //EntityState state = _dbContext.Entry(entity).State;

            //_ = state switch
            //{
            //    EntityState.Detached => _dbSet.Add(entity),
            //    EntityState.Modified => _dbSet.Update(entity)
            //};


            //await _dbContext.SaveChangesAsync();

            //return entity;
            throw new NotImplementedException();
        }
    }
}
