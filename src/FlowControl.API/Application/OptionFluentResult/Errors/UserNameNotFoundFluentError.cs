using FluentResults;

namespace FlowControl.API.Application.OptionFluentResult.Errors;

public class UserNameNotFoundFluentError : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => throw new NotImplementedException();

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}
