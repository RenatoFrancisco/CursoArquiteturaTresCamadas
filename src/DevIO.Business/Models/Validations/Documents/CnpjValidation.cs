namespace DevIO.Business.Models.Validations.Documents;

public class CnpjValidation
{
    public const int CNPJ_LENGTH = 14;

    public static bool Validate(string? document) => new CNPJValidator().IsValid(document);
}