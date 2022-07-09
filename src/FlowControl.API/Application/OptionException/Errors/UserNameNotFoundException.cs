using System.Net;

namespace FlowControl.API.Application.OptionException.Errors;

public class UserNameNotFoundException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public string ErroMessage => "Este usuário não existe!";
}
