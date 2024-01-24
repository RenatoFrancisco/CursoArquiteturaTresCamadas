using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers;

[Route("api/products")]
public class ProductsController : MainController
{
    private readonly IProductRepository _productRepository;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductsController(IProductRepository productRepository, IProductService productService, IMapper mapper)
    {
        _productRepository = productRepository;
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductViewModel>> GetAll() =>
        _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetAll());


    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> GetById(Guid id)
    {
        var productViewModel = await GetProduct(id);

        if (productViewModel is null) return NotFound();

        return productViewModel;
    }
    

    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> Add(ProductViewModel productViewModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _productService.AddAsync(_mapper.Map<Product>(productViewModel));

        return CustomResponse(productViewModel);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> Update(Guid id, ProductViewModel productViewModel)
    {
        if (id != productViewModel.Id)
        {
            NotifyError("The supplied ids are not equal");
            return CustomResponse();
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var updatedProduct = await GetProduct(id);
        updatedProduct.Name = productViewModel.Name;
        updatedProduct.Description = productViewModel.Description;
        updatedProduct.Value = productViewModel.Value;
        updatedProduct.Active = productViewModel.Active;

        await _productService.UpdateAsync(_mapper.Map<Product>(updatedProduct));

        return CustomResponse();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> Delete(Guid id)
    {
         var productViewModel = await GetProduct(id);

        if (productViewModel is null) return NotFound();

        await _productService.RemoveAsync(id);

        return CustomResponse();
    }

    private async Task<ProductViewModel> GetProduct(Guid id) =>
        _mapper.Map<ProductViewModel>(await _productRepository.GetById(id));
}
