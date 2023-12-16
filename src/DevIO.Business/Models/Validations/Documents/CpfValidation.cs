namespace DevIO.Business.Models.Validations.Documents;

public class CpfValidation
{
    public const int CPF_LENGTH = 11;

    public static bool Validate(string? document) => new CPFValidator().IsValid(document);
}