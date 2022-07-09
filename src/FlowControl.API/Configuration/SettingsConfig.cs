using FlowControl.API.Common;
using Microsoft.Extensions.Options;

namespace FlowControl.API.Configuration;

public static class SettingsConfig
{
    public static IServiceCollection AddSettingsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var tokenConfigurations = new TokenConfigurations();
        new ConfigureFromConfigurationOptions<TokenConfigurations>(configuration.GetSection("TokenConfigurations")).Configure(tokenConfigurations);

        services.AddSingleton(tokenConfigurations);

        return services;
    }

}
