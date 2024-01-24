using System.Net;
using DevIO.Business.Interfaces;
using DevIO.Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevIO.Api.Controllers;

[ApiController]
public abstract class MainController(INotifier notifier) : ControllerBase
{
    private readonly INotifier _notifier = notifier;

    protected bool ValidOperation() => !_notifier.HasNotification();

    protected ActionResult CustomResponse(HttpStatusCode statusCode = HttpStatusCode.OK, object result = null)
    {
        if (ValidOperation()) 
            return new ObjectResult(result) { StatusCode = (int)statusCode };

        return BadRequest(new 
        {
            errors = _notifier.GetNotifications().Select(n => n.Message)
        });
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid) NotifyInvalidErrorModel(modelState);

        return CustomResponse();
    }

    protected void NotifyInvalidErrorModel(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(e => e.Errors);

        errors.ToList().ForEach(e => 
        {
            var errorMsg = e.Exception is null ? e.ErrorMessage : e.Exception.Message;
            NotifyError(errorMsg);
        });
    }

    protected void NotifyError(string message) => _notifier.Handle(new Notification(message));
}   