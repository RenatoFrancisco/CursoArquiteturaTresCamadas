namespace DevIO.Business.Interfaces;

public interface ISupplierRepository : IRepository<Supplier>
{
    Task<Supplier> GetSupplierWithAddressAsync(Guid id);
    Task<Supplier> GetSupplierWithProductsAndAddressAsync(Guid id);
    Task<Address> GetAddresBySupplierAsync(Guid supplierId);
    Task RemoveSupplierAddressAsync(Address address);
}