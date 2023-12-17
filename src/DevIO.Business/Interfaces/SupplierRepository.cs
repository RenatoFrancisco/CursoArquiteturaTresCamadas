namespace DevIO.Business.Interfaces;

public interface SupplierRepository : IRepository<Supplier>
{
    Task<Supplier> GetSupplerWithAddress(Guid id);
    Task<Supplier> GetSupplerWithProductsAndAddress(Guid id);
    Task<Address> GetAddresBySupplier(Guid supplierId);
}