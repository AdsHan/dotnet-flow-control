using System.Net;

namespace FlowControl.API.Application.OptionOneOf.Errors;

public class CredentialsInvalidOneOfError : IServiceError
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public string ErroMessage => "Usuário ou Senha incorretos!";
}
