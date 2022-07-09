using ErrorOr;
using FlowControl.API.Application.OptionErrorOr;
using FlowControl.API.Common;
using FlowControl.API.Domain.Data.Entities;
using FlowControl.API.Domain.DTO;
using Microsoft.AspNetCore.Identity;

namespace FlowControl.API.Application.OptionFluentResult;

public class AuthErrorOrService : BaseService
{

    public AuthErrorOrService(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager) : base(userManager, signInManager)
    {
    }

    public async Task<ErrorOr<BaseResult>> ValidateCredentialsAsync(AccessCredentialsDTO credentials)
    {
        var isIncluded = await _userManager.FindByEmailAsync(credentials.Email);

        if (isIncluded == null)
        {
            return ErrorsDomain.Auth.UserNameNotFound;
        }

        var signIn = await _signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, isPersistent: false, lockoutOnFailure: true);

        if (!signIn.Succeeded)
        {
            return ErrorsDomain.Auth.CredentialsInvalid;
        }

        if (signIn.IsLockedOut)
        {
            return ErrorsDomain.Auth.UserIsBlocked;
        }

        return result;
    }
}

