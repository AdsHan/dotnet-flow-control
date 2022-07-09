using FlowControl.API.Application.OptionFluentResult;
using FlowControl.API.Application.OptionManual;
using FlowControl.API.Application.OptionOneOf;
using FlowControl.API.Common;
using FlowControl.API.Domain;
using FlowControl.API.Domain.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlowControl.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services)
    {
        // Usando com banco de dados em memória
        services.AddDbContext<AuthDbContext>(options => options.UseInMemoryDatabase("AuthDB"));

        services.AddIdentity<UserModel, IdentityRole>(options =>
        {
            // Configurações de senha
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 2;
            options.Password.RequiredUniqueChars = 0;
        }).AddErrorDescriber<IdentityPortugues>()
          .AddEntityFrameworkStores<AuthDbContext>()
          .AddDefaultTokenProviders();

        services.AddScoped<AuthManualService>();
        services.AddScoped<AuthOneOfService>();
        services.AddScoped<AuthExceptionService>();
        services.AddScoped<AuthFluentResultService>();
        services.AddScoped<AuthErrorOrService>();

        services.AddTransient<UserInitializerService>();

        return services;
    }
}
