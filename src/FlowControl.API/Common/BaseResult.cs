namespace FlowControl.API.Common;

public class BaseResult
{
    public List<string> Errors { get; set; }
    public object Response { get; set; }

    public BaseResult()
    {
        Errors = new List<string>();
        Response = null;
    }

    public bool IsValid()
    {
        return !Errors.Any();
    }

    public string GetErrorsMessages()
    {
        return string.Concat(Errors.ToArray());
    }

}
