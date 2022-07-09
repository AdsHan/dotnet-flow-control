using ErrorOr;

namespace FlowControl.API.Application.OptionErrorOr;

public static class ErrorsDomain
{
    public static class Auth
    {
        public static Error CredentialsInvalid => Error.Validation(code: "Auth.CredentialsInvalid", description: "Usuário ou Senha incorretos!");
        public static Error UserIsBlocked => Error.Validation(code: "Auth.UserIsBlocked", description: "Usuário temporariamente bloqueado por tentativas inválidas!");
        public static Error UserNameNotFound => Error.Validation(code: "Auth.UserNameNotFound", description: "Este usuário não existe!");
    }
}
