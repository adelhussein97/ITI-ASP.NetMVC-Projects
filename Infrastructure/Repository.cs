using Application.Contract;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    // Repository Pattern
    // Unit of Work >>> Not Create more than one object of context
    public abstract class Repository<TEntity,TContext, TID> :IRepository<TEntity, TID> 
        where TEntity : class where TContext : DbContext
    {
       
        private readonly DbSet<TEntity> dbset;
        protected TContext Context { get; } 

        public Repository(TContext context) 
        {
            dbset = context.Set<TEntity>();
            Context=context;
        }
        public async Task<TEntity?> GetDetailsAsync(TID id)
        {
            return await dbset.FindAsync(id);
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
           return (await dbset.AddAsync(entity)).Entity;
        }
        // Using this Function When Return ID to use it in another entity
        public async Task<TEntity> CreateOnDBsAsync(TEntity entity)
        {
            var data=await CreateAsync(entity);
            await SaveOnDBChanges();
            return data;

        }

        public async Task<bool> DeleteAsync(TID id)
        {
            var item=await GetDetailsAsync(id);
            if (item!=null)
            {
                dbset.Remove(item);
                return true;
            }
            else
                return false;
           
        }

        public Task<bool> UpdateAsync(TEntity entity)
        {
            var item = dbset.Update(entity);
            Task<bool> task = (item != null) ? Task.FromResult(true) : Task.FromResult(false);
            return task;

        }
        // Use it once after making all changes calling this func to sava once 
        public async Task<int> SaveOnDBChanges()
        {
            return await Context.SaveChangesAsync();
        }

       
    }
}
