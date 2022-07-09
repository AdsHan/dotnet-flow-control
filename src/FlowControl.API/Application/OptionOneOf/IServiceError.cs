using System.Net;

namespace FlowControl.API.Application.OptionOneOf;

public interface IServiceError
{
    public HttpStatusCode StatusCode { get; }
    public string ErroMessage { get; }
}
