namespace DevIO.Business.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IQueryable<Product>> GetProductsBySupplier(Guid supplierId);
    Task<IQueryable<Product>> GetProducstWithSupplier();
    Task<Product> GetProductWithSupplier(Guid id);
}