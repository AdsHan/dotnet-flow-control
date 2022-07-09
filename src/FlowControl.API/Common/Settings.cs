namespace FlowControl.API.Common;

public class TokenConfigurations
{
    public string SecretJWTKey { get; set; }
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public int ExpireSeconds { get; set; }
    public int FinalExpirationSeconds { get; set; }

}
