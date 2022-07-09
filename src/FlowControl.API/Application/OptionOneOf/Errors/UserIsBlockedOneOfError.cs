using System.Net;

namespace FlowControl.API.Application.OptionOneOf.Errors;

public class UserIsBlockedOneOfError : IServiceError
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public string ErroMessage => "Usuário temporariamente bloqueado por tentativas inválidas!";
}
