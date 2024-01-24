using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevIO.Api.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    protected bool ValidOperation() => true;

    protected ActionResult CustomResponse(object result = null)
    {
        if (ValidOperation()) return new ObjectResult(result);

        return BadRequest(new 
        {

        });
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid) { }

        return CustomResponse();
    }

    protected void NotifyError(string message)
    {
        
    }
}