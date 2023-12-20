namespace DevIO.Business.Services;

public class ProductService(IProductRepository productRepository) : BaseService, IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task AddAsync(Product product)
    {
        await _productRepository.AddAsync(product);
    }

    public async Task UpdateAsync(Product product)
    {
        await _productRepository.UpdateAsync(product);
    }

    public async Task RemoveAsync(Guid id)
    {
        await _productRepository.RemoveAsync(id);
    }

    public void Dispose()
    {
        _productRepository?.Dispose();
    }
}