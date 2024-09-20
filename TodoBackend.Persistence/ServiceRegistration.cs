using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TodoBackend.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        //Ioc container for persistence layer
        //services.AddSingleton<IService, Service>();
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer("Server=DESKTOP-K1K3TFG\\SQLEXPRESS;Database=TodoDb;TrustServerCertificate=true;Trusted_Connection=True;",
                optionsBuilder => optionsBuilder.EnableRetryOnFailure());
        });
    }
}