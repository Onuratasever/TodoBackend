using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoBackend.Domain.Entities.TodoItem;
using TodoBackend.Domain.Entities.TodoList;

namespace TodoBackend.Persistence.Configurations;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.HasKey(ti => ti.Id);
        builder.Property(ti => ti.TodoListId).IsRequired();
        builder.Property(ti => ti.Title).IsRequired().HasMaxLength(200);
        builder.Property(ti => ti.Description).HasMaxLength(1000);
        builder.Property(ti => ti.Status).IsRequired().HasMaxLength(50);
        builder.Property(ti => ti.Priority).IsRequired().HasMaxLength(50);
        builder.Property(ti => ti.DueDate).IsRequired();

        // Foreign Key Configuration for TodoList
        builder.HasOne<TodoList>()
            .WithMany()
            .HasForeignKey(ti => ti.TodoListId)
            .OnDelete(DeleteBehavior.Cascade);  // Optional: Cascade delete

        builder.Property(ti => ti.CreatedAt).IsRequired();
        builder.Property(ti => ti.UpdatedAt).IsRequired();
    }
}