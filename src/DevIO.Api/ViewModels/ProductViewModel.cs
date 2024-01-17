using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.ViewModels;
public class ProductViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "The field {0} is mandatory")]
    public Guid SupplierId { get; set; }

    [Required(ErrorMessage = "The field {0} is mandatory")]
    [StringLength(200, ErrorMessage = "The field {0} must contain between {2} and {1} characters", MinimumLength = 2)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The field {0} is mandatory")]
    [StringLength(1000, ErrorMessage = "The field {0} must contain between {2} and {1} characters", MinimumLength = 2)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "The field {0} is mandatory")]
    public decimal Value { get; set; }
    public DateTime ResgisteredOn { get; set; }
    public bool Active { get; set; }
    public string? SupplierName { get; set; }
}