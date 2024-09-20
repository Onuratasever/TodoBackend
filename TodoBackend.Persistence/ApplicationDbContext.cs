using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using TodoBackend.Domain.Entities.AuditLog;
using TodoBackend.Domain.Entities.Auth;
using TodoBackend.Domain.Entities.Comment;
using TodoBackend.Domain.Entities.SubTask;
using TodoBackend.Domain.Entities.TodoItem;
using TodoBackend.Domain.Entities.TodoList;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Persistence;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Auth> Auths { get; set; }
    public DbSet<TodoList> TodoLists { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<SubTask> SubTasks { get; set; }
    public DbSet<TodoItem> TodoItems { get; set; }
    
}