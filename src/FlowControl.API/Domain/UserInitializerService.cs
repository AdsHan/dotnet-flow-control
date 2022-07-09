using FlowControl.API.Domain.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace FlowControl.API.Domain;

public class UserInitializerService
{
    private readonly AuthDbContext _context;
    private readonly UserManager<UserModel> _userManager;

    public UserInitializerService(AuthDbContext context, UserManager<UserModel> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public void Initialize()
    {
        if (_context.Database.EnsureCreated())
        {
            CreateUser(
                new UserModel()
                {
                    UserName = "adshan@gmail.com",
                    Email = "adshan@gmail.com",
                    EmailConfirmed = true
                }, "123456");
        }
    }

    private void CreateUser(UserModel user, string password)
    {
        if (_userManager.FindByNameAsync(user.UserName).Result == null)
        {
            var resultado = _userManager.CreateAsync(user, password).Result;
        }
    }
}
