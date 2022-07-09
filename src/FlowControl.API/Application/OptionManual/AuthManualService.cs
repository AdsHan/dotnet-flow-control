using FlowControl.API.Common;
using FlowControl.API.Domain.Data.Entities;
using FlowControl.API.Domain.DTO;
using Microsoft.AspNetCore.Identity;

namespace FlowControl.API.Application.OptionManual;

public class AuthManualService : BaseService
{
    public AuthManualService(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager) : base(userManager, signInManager)
    {
    }

    public async Task<BaseResult> ValidateCredentialsAsync(AccessCredentialsDTO credentials)
    {
        var isIncluded = await _userManager.FindByEmailAsync(credentials.Email);

        if (isIncluded == null)
        {
            AddError("Este usuário não existe!");
            return result;
        }

        var signIn = await _signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, isPersistent: false, lockoutOnFailure: true);

        if (!signIn.Succeeded)
        {
            AddError("Usuário ou Senha incorretos!");
            return result;
        }

        if (signIn.IsLockedOut)
        {
            AddError("Usuário temporariamente bloqueado por tentativas inválidas!");
            return result;
        }

        return result;
    }

}

