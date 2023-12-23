namespace DevIO.Business.Services;

public abstract class BaseService
{

    protected void Notify(string message)
    {
        
    }

    protected bool ExecuteValidation<TV, TE>(TV validation, TE entity)
        where TV : AbstractValidator<TE>
        where TE : Entity
    {
        var validator = validation.Validate(entity);
        if (validator.IsValid) return true;

        return false;
    }
}