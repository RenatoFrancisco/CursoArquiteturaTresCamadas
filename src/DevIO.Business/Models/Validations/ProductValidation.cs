namespace DevIO.Business.Models.Validations;

public class ProductValidation : AbstractValidator<Product>
{
    public ProductValidation()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("The field {PropertyName} must be supplied")
            .Length(2, 200).WithMessage("The field {PropertyName} must contain between {MinLength} and {MaxLength} characters");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("The field {PropertyName} must be supplied")
            .Length(2, 1000).WithMessage("The field {PropertyName} must contain between {MinLength} and {MaxLength} characters");

        RuleFor(p => p.Value)
            .GreaterThan(0).WithMessage("The field {PropertyName} must be greater than {comparisonValue}");

    }
}