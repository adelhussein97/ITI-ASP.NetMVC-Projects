

namespace Application.Contract
{
    public interface IRepository <TEntity,TID> where TEntity : class 
    {
        Task<TEntity?> GetDetailsAsync(TID id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TID id);

        Task<int> SaveOnDBChanges();
        
    }
}
