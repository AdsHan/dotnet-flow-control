using System.Net;

namespace FlowControl.API.Application.OptionException.Errors;

public class UserIsBlockedException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public string ErroMessage => "Usuário temporariamente bloqueado por tentativas inválidas!";
}
