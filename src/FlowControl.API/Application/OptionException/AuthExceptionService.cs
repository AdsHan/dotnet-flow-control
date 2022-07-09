using FlowControl.API.Application.OptionException.Errors;
using FlowControl.API.Common;
using FlowControl.API.Domain.Data.Entities;
using FlowControl.API.Domain.DTO;
using Microsoft.AspNetCore.Identity;

namespace FlowControl.API.Application.OptionManual;

public class AuthExceptionService : BaseService
{

    public AuthExceptionService(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager) : base(userManager, signInManager)
    {
    }

    public async Task<BaseResult> ValidateCredentialsAsync(AccessCredentialsDTO credentials)
    {
        var isIncluded = await _userManager.FindByEmailAsync(credentials.Email);

        if (isIncluded == null)
        {
            throw new UserNameNotFoundException();
        }

        var signIn = await _signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, isPersistent: false, lockoutOnFailure: true);

        if (!signIn.Succeeded)
        {
            throw new CredentialsInvalidException();
        }

        if (signIn.IsLockedOut)
        {
            throw new UserIsBlockedException();
        }

        return result;
    }
}

