using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoBackend.Domain.Entities.TodoList;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Persistence.Configurations;

public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
{
    public void Configure(EntityTypeBuilder<TodoList> builder)
    {
        builder.HasKey(tl => tl.Id);
        builder.Property(tl => tl.UserId).IsRequired();
        builder.Property(tl => tl.Title).IsRequired().HasMaxLength(200);

        // Foreign Key Configuration for User
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(tl => tl.UserId)
            .OnDelete(DeleteBehavior.Cascade);  // Optional: Cascade delete
        
        builder.Property(tl => tl.CreatedAt).IsRequired();
        builder.Property(tl => tl.UpdatedAt).IsRequired();
    }
}