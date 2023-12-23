namespace DevIO.Business.Services;

public abstract class BaseService(INotifier notifier)
{
    private readonly INotifier _notifier = notifier;

    protected void Notify(ValidationResult validationResult) =>
        validationResult.Errors.ForEach(e => Notify(e.ErrorMessage));

    protected void Notify(string message) => _notifier.Handle(new Notification(message));

    protected bool ExecuteValidation<TV, TE>(TV validation, TE entity)
        where TV : AbstractValidator<TE>
        where TE : Entity
    {
        var validator = validation.Validate(entity);
        if (validator.IsValid) return true;

        Notify(validator);

        return false;
    }
}