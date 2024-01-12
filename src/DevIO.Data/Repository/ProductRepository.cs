using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository;

public class ProductRepository(EfDbContext db) : Repository<Product>(db), IProductRepository
{
    public async Task<Product> GetProductWithSupplierAsync(Guid id) => 
        await Db.Products
            .AsNoTracking()
            .Include(s => s.Supplier)
            .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<Product>> GetProductsWithSupplierAsync() =>
        await Db.Products
            .AsNoTracking()
            .Include(s => s.Supplier)
            .OrderBy(p => p.Name)
            .ToListAsync();

    public async Task<IEnumerable<Product>> GetProductsBySupplierASync(Guid supplierId) =>
        await Search(p => p.SupplierId == supplierId);
}