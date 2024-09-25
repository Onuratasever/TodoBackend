using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoBackend.Domain.Entities.AuditLog;
using TodoBackend.Domain.Entities.Auth;
using TodoBackend.Domain.Entities.Comment;
using TodoBackend.Domain.Entities.SubTask;
using TodoBackend.Domain.Entities.TodoItem;
using TodoBackend.Domain.Entities.TodoList;
using TodoBackend.Domain.Entities.User;
using TodoBackend.Persistence.Repositories;

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
        
        services.AddScoped<IAuditLogRepository, AuditLogRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ISubTaskRepository, SubTaskRepository>();
        services.AddScoped<ITodoItemRepository, TodoItemRepository>();
        services.AddScoped<ITodoListRepository, TodoListRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

    }
}