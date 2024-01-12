namespace DevIO.Business.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsBySupplierASync(Guid supplierId);
    Task<IEnumerable<Product>> GetProductsWithSupplierAsync();
    Task<Product> GetProductWithSupplierAsync(Guid id);
}