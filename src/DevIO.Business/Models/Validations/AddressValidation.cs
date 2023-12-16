namespace DevIO.Business.Models.Validations;

public class AddressValidation : AbstractValidator<Address>
{
    public AddressValidation()
    {
        RuleFor(p => p.Street)
            .NotEmpty().WithMessage("The field {PropertyName} must be supplied")
            .Length(2, 200).WithMessage("The field {PropertyName} must contain between {MinLength} and {MaxLength} characters");

        RuleFor(p => p.District)
            .NotEmpty().WithMessage("The field {PropertyName} must be supplied")
            .Length(2, 100).WithMessage("The field {PropertyName} must contain between {MinLength} and {MaxLength} characters");

        RuleFor(p => p.ZipCode)
            .NotEmpty().WithMessage("The field {PropertyName} must be supplied")
            .Length(8).WithMessage("The field {PropertyName} must contain {MaxLength} characters");

        RuleFor(p => p.City)
            .NotEmpty().WithMessage("The field {PropertyName} must be supplied")
            .Length(2, 100).WithMessage("The field {PropertyName} must contain between {MinLength} and {MaxLength} characters");

        RuleFor(p => p.State)
            .NotEmpty().WithMessage("The field {PropertyName} must be supplied")
            .Length(2, 50).WithMessage("The field {PropertyName} must contain between {MinLength} and {MaxLength} characters");

        RuleFor(p => p.Number)
            .NotEmpty().WithMessage("The field {PropertyName} must be supplied")
            .Length(1, 50).WithMessage("The field {PropertyName} must contain between {MinLength} and {MaxLength} characters");
    }
}