using System.Net;

namespace FlowControl.API.Application.OptionException.Errors;

public class CredentialsInvalidException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public string ErroMessage => "Usuário ou Senha incorretos!";
}
