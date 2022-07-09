using System.Net;

namespace FlowControl.API.Application.OptionException;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErroMessage { get; }
}
