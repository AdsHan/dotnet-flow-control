using System.Net;

namespace FlowControl.API.Application.OptionOneOf.Erros;

public class UserNameNotFoundOneOfError : IServiceError
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public string ErroMessage => "Este usuário não existe!";
}
