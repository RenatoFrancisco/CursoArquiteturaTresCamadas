using System.Linq.Expressions;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository;

public abstract class Repository<TEntity>(DbContext db) : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly DbContext Db = db;
    protected readonly DbSet<TEntity> DbSet = db.Set<TEntity>();

    public virtual async Task<List<TEntity>> GetAll() => await DbSet.ToListAsync();

    public virtual async Task<TEntity> GetById(Guid id) => await DbSet.FindAsync(id);

    public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate) =>
        await DbSet.AsNoTracking().Where(predicate).ToListAsync();

    public virtual async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await SaveChanges();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await SaveChanges();
    }

    public virtual async Task RemoveAsync(Guid id)
    {
        DbSet.Remove(new TEntity { Id = id });
        await SaveChanges();
    }

    public async Task<int> SaveChanges() => await Db.SaveChangesAsync();

    public void Dispose() => Db?.Dispose();
}