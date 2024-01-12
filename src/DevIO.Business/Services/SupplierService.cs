namespace DevIO.Business.Services;

public class SupplierService(ISupplierRepository supplierRepository, INotifier notifier) : BaseService(notifier), ISupplierService
{
    private readonly ISupplierRepository _supplierRepository = supplierRepository;

    public async Task AddAsync(Supplier supplier)
    {
        if (!ExecuteValidation(new SupplierValidation(), supplier)
            || !ExecuteValidation(new AddressValidation(), supplier.Address)) return;

        if (_supplierRepository.Search(s => s.Document == supplier.Document).Result.Any())
        {
            Notify("Already exists a supplier with this document.");
            return;
        }

        await _supplierRepository.AddAsync(supplier);
    }

    public async Task UpdateAsync(Supplier supplier)
    {
        if (!ExecuteValidation(new SupplierValidation(), supplier)) return;

        if (_supplierRepository.Search(s => s.Document == supplier.Document && s.Id == supplier.Id).Result.Any())
        {
            Notify("Already exists a supplier with this document.");
            return;
        }

        await _supplierRepository.UpdateAsync(supplier);
    }

    public async Task RemoveAsync(Guid id)
    {
        var supplier = await _supplierRepository.GetSupplierWithProductsAndAddressAsync(id);
        if (supplier is null)
        {
            Notify("Supplier does not exist!");
            return;
        }

        if (supplier.Products.Any())
        {
            Notify("The supplier has assciated products!");
            return;
        }

        var address = await _supplierRepository.GetAddresBySupplierAsync(id);
        if (address is not null)
        {
            await _supplierRepository.RemoveSupplierAddressAsync(address);
        }

        await _supplierRepository.RemoveAsync(id);
    }

     public void Dispose() => _supplierRepository?.Dispose();
}