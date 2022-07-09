using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FlowControl.API.Application.OptionException;

[ApiController]
public class ErrorController : ControllerBase
{

    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult GetError([FromServices] IWebHostEnvironment env)
    {

        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;

        var (statusCode, title) = exception switch
        {
            IServiceException service => ((int)service.StatusCode, service.ErroMessage),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured.")
        };

        return ValidationProblem(statusCode: statusCode, title: title);
    }

}
