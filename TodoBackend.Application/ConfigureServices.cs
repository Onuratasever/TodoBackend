using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TodoBackend.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(AssemblyReference.Application); // değiştir
        });
        return services; // değiştir
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}