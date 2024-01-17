using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.ViewModels;

public class SupplierViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "The field {0} is mandatory")]
    [StringLength(100, ErrorMessage = "The field {0} must contain between {2} and {1} characters", MinimumLength = 2)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The field {0} is mandatory")]
    [StringLength(14, ErrorMessage = "The field {0} must contain between {2} and {1} characters", MinimumLength = 11)]
    public string? Document { get; set; }
    public int SupplierType { get; set; }
    public bool Active { get; set; }
    public AddressViewModel? Address { get; set; }
    public IEnumerable<ProductViewModel>? Products { get; set; }
}