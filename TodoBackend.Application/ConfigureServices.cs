using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TodoBackend.Application.Users.Create;

namespace TodoBackend.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(AssemblyReference.Application);
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(AssemblyReference.Application); // değiştir
        });
        // services.AddFluentValidation(configuration =>
        //     configuration.RegisterValidatorsFromAssemblyContaining<AssemblyReference.Application>());
        return services; // değiştir
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}