using System.Net;
using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers;

[Route("api/suppliers")]
public class SuppliersController(ISupplierRepository supplierRepository,
                                 ISupplierService supplierService,
                                 IMapper mapper,
                                 INotifier notifier) : MainController(notifier)
{
    private readonly ISupplierRepository _supplierRepository = supplierRepository;
    private readonly ISupplierService _supplierService = supplierService;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IEnumerable<SupplierViewModel>> GetAll() =>
        _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll());

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SupplierViewModel>> GetById(Guid id)
    {
        var supplierViewModel = await GetSupplier(id);

        if (supplierViewModel is null) return NotFound();

        return supplierViewModel;
    }

    [HttpPost]
    public async Task<ActionResult<SupplierViewModel>> Add(SupplierViewModel supplierViewModel)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _supplierService.AddAsync(_mapper.Map<Supplier>(supplierViewModel));

        return CustomResponse(HttpStatusCode.Created, supplierViewModel);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<SupplierViewModel>> Update(Guid id, SupplierViewModel supplierViewModel)
    {
        if (id != supplierViewModel.Id)
        {
            NotifyError("The supplied ids are not equal");
            return CustomResponse();
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _supplierService.UpdateAsync(_mapper.Map<Supplier>(supplierViewModel));

        return CustomResponse(HttpStatusCode.NoContent);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<SupplierViewModel>> Delete(Guid id)
    {
         var supplierViewModel = await GetSupplier(id);

        if (supplierViewModel is null) return NotFound();

        await _supplierService.RemoveAsync(id);

        return CustomResponse(HttpStatusCode.NoContent);
    }

    private async Task<SupplierViewModel> GetSupplier(Guid id) =>
        _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierWithProductsAndAddressAsync(id));
}