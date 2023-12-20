namespace DevIO.Business.Services;

public class SupplierService(ISupplierRepository supplierRepository) : BaseService, ISupplierService
{
    private readonly ISupplierRepository _supplierRepository = supplierRepository;

    public async Task AddAsync(Supplier supplier)
    {
        if (!ExecuteValidation(new SupplierValidation(), supplier)
            || !ExecuteValidation(new AddressValidation(), supplier.Address)) return;

        await _supplierRepository.AddAsync(supplier);
    }

    public async Task UpdateAsync(Supplier supplier)
    {
        if (!ExecuteValidation(new SupplierValidation(), supplier)) return;

        await _supplierRepository.UpdateAsync(supplier);
    }

    public async Task RemoveAsync(Guid id)
    {
        await _supplierRepository.RemoveAsync(id);
    }

     public void Dispose()
    {
        _supplierRepository?.Dispose();
    }
}