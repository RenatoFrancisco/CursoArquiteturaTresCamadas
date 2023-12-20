namespace DevIO.Business.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IQueryable<Product>> GetProductsBySupplierASync(Guid supplierId);
    Task<IQueryable<Product>> GetProducstWithSupplierAsync();
    Task<Product> GetProductWithSupplierAsync(Guid id);
}