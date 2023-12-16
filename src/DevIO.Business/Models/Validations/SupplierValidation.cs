namespace DevIO.Business.Models.Validations;

public class SupplierValidation : AbstractValidator<Supplier>
{
    public SupplierValidation()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("The field {PropertyName} must be supplied")
            .Length(2, 100).WithMessage("The field {PropertyName} must contain between {MinLength} and {MaxLength} characters");


        When(p => p.SupplierType == SupplierType.NaturalPerson, () => 
        {
            RuleFor(p => p.Document.Length).Equal(CpfValidation.CPF_LENGTH)
                .WithMessage("The field Document must contain {comparisonValue} but was supplied {PropertyValue}");

            RuleFor(P => CpfValidation.Validate(P.Document)).Equal(true)
                .WithMessage("The supplied document is invalid.");
        });

        When(p => p.SupplierType == SupplierType.Entity, () => 
        {
            RuleFor(p => p.Document.Length).Equal(CnpjValidation.CNPJ_LENGTH)
                .WithMessage("The field Document must contain {comparisonValue} but was supplied {PropertyValue}");

            RuleFor(P => CnpjValidation.Validate(P.Document)).Equal(true)
                .WithMessage("The supplied document is invalid.");
        });
    }
}