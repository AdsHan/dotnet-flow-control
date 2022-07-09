using FlowControl.API.Application.OptionFluentResult.Errors;
using FlowControl.API.Common;
using FlowControl.API.Domain.Data.Entities;
using FlowControl.API.Domain.DTO;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace FlowControl.API.Application.OptionFluentResult;

public class AuthFluentResultService : BaseService
{

    public AuthFluentResultService(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager) : base(userManager, signInManager)
    {
    }

    public async Task<Result<BaseResult>> ValidateCredentialsAsync(AccessCredentialsDTO credentials)
    {
        var isIncluded = await _userManager.FindByEmailAsync(credentials.Email);

        if (isIncluded == null)
        {
            return Result.Fail<BaseResult>(new[] { new UserNameNotFoundFluentError() });
        }

        var signIn = await _signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, isPersistent: false, lockoutOnFailure: true);

        if (!signIn.Succeeded)
        {
            return Result.Fail<BaseResult>(new[] { new CredentialsInvalidFluentError() });
        }

        if (signIn.IsLockedOut)
        {
            return Result.Fail<BaseResult>(new[] { new UserIsBlockedFluentError() });
        }

        return result;
    }
}

