namespace DevIO.Business.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task AddAsync(TEntity entity);
    Task<TEntity> GetById(Guid id);
    Task<List<TEntity>> GetAll();
    Task UpdateAsync(TEntity entity);
    Task RemoveAsync(Guid id);
    Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
}