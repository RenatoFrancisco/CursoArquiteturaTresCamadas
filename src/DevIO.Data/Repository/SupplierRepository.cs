using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository;

public class SupplierRepository(EfDbContext db) : Repository<Supplier>(db), ISupplierRepository
{
    public async Task<Supplier> GetSupplierWithAddressAsync(Guid id) =>
        await Db.Suppliers
            .AsNoTracking()
            .Include(s => s.Address)
            .FirstOrDefaultAsync(s => s.Id == id);

    public async Task<Supplier> GetSupplierWithProductsAndAddressAsync(Guid id) =>
        await Db.Suppliers
            .AsNoTracking()
            .Include(s => s.Products)
            .Include(s => s.Address)
            .FirstOrDefaultAsync(s => s.Id == id);

    public async Task<Address> GetAddresBySupplierAsync(Guid supplierId) =>
        await Db.Addresses
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.SupplierId == supplierId);

    public async Task RemoveSupplierAddressAsync(Address address)
    {
        Db.Addresses.Remove(address);
        await SaveChanges();
    }
}