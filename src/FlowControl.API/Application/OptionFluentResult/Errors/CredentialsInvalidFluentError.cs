using FluentResults;

namespace FlowControl.API.Application.OptionFluentResult.Errors;

public class CredentialsInvalidFluentError : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => throw new NotImplementedException();

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}
