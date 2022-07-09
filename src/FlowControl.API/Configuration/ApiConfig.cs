using FlowControl.API.Domain;

namespace FlowControl.API.Configuration;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        return services;
    }

    public static WebApplication UseApiConfiguration(this WebApplication app)
    {
        // Inserido o Exception Handler
        app.UseExceptionHandler("/error");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var service = services.GetRequiredService<UserInitializerService>();
                service.Initialize();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Ocorreu um erro na inicialização");
            }
        }

        return app;
    }

}