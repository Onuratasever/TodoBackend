using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TodoBackend.Persistence;

public static class ConfigureServices
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Ioc container for persistence layer
        //services.AddSingleton<IService, Service>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        // Ensure.NotNull(connectionString, nameof(connectionString));
        if (connectionString == null)
        {
            throw new ArgumentNullException(connectionString);
        }
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString,
                optionsBuilder => optionsBuilder.EnableRetryOnFailure());
        });
    }
}