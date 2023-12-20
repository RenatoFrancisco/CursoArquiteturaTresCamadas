namespace DevIO.Business.Interfaces;

public interface ISupplierRepository : IRepository<Supplier>
{
    Task<Supplier> GetSupplerWithAddressAsync(Guid id);
    Task<Supplier> GetSupplerWithProductsAndAddressAsync(Guid id);
    Task<Address> GetAddresBySupplierAsync(Guid supplierId);
}