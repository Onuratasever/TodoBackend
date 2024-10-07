using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TodoBackend.Abstraction;
using Asp.Versioning;

namespace TodoBackend;

public static class ConfigureServices
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        var serviceDescriptors = assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .ToArray();
        
        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }
    
    public static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
    {
        var endpointTypes = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;
        foreach (var endpoint in endpointTypes)
        {
            endpoint.MapEndpoint(builder);
        }

        return app;
    }

    public static RouteGroupBuilder CreateVersionedRouteGroup(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = app
            .NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1, 0))
            .HasApiVersion(new ApiVersion(2, 0))
            .ReportApiVersions()
            .Build();
        
        return app
            .MapGroup("api/v{apiVersion:apiVersion}")
            .WithApiVersionSet(apiVersionSet);

    }
    
    public static IServiceCollection AddApiVersioningCustom(this IServiceCollection services)
    {
        services.AddApiVersioning(o =>
        {
            o.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));
            o.DefaultApiVersion = new ApiVersion(1, 0);
            o.AssumeDefaultVersionWhenUnspecified = true;  // Eğer versiyon belirtilmezse varsayılanı kullan
            o.ReportApiVersions = true;  // API versiyonlarını raporla
        }).AddApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            }
            );

        return services;
    }
}