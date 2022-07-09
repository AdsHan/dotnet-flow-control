using FlowControl.API.Application.OptionOneOf.Errors;
using FlowControl.API.Application.OptionOneOf.Erros;
using FlowControl.API.Common;
using FlowControl.API.Domain.Data.Entities;
using FlowControl.API.Domain.DTO;
using Microsoft.AspNetCore.Identity;
using OneOf;

namespace FlowControl.API.Application.OptionOneOf;

public class AuthOneOfService : BaseService
{

    public AuthOneOfService(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager) : base(userManager, signInManager)
    {
    }

    public async Task<OneOf<BaseResult, IServiceError>> ValidateCredentialsAsync(AccessCredentialsDTO credentials)
    {
        var isIncluded = await _userManager.FindByEmailAsync(credentials.Email);

        if (isIncluded == null)
        {
            return new UserNameNotFoundOneOfError();
        }

        var signIn = await _signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, isPersistent: false, lockoutOnFailure: true);

        if (!signIn.Succeeded)
        {
            return new CredentialsInvalidOneOfError();
        }

        if (signIn.IsLockedOut)
        {
            return new UserIsBlockedOneOfError();
        }

        return result;
    }
}

