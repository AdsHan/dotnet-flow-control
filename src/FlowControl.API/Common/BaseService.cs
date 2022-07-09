using FlowControl.API.Domain.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace FlowControl.API.Common;

public abstract class BaseService
{
    protected readonly UserManager<UserModel> _userManager;
    protected readonly SignInManager<UserModel> _signInManager;

    protected BaseResult result;

    protected BaseService(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;

        result = new BaseResult();
    }

    protected void AddError(string message)
    {
        result.Errors.Add(message);
    }
}
