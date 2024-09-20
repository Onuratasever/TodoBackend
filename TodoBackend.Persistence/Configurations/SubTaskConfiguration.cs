using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoBackend.Domain.Entities.SubTask;
using TodoBackend.Domain.Entities.TodoItem;

namespace TodoBackend.Persistence.Configurations;

public class SubTaskConfiguration : IEntityTypeConfiguration<SubTask>
{
    public void Configure(EntityTypeBuilder<SubTask> builder)
    {
        builder.HasKey(st => st.Id);
        builder.Property(st => st.MainTaskId).IsRequired();
        builder.Property(st => st.Description).HasMaxLength(1000);
        builder.Property(st => st.priority).IsRequired().HasMaxLength(50);
        builder.Property(st => st.Title).IsRequired().HasMaxLength(200);
        builder.Property(st => st.IsCompleted).IsRequired();
        builder.Property(st => st.DueDate).IsRequired();

        // Foreign Key Configuration for TodoItem (MainTask)
        builder.HasOne<TodoItem>()
            .WithMany()
            .HasForeignKey(st => st.MainTaskId)
            .OnDelete(DeleteBehavior.Cascade);  // Optional: Cascade delete

        builder.Property(st => st.CreatedAt).IsRequired();
        builder.Property(st => st.UpdatedAt).IsRequired();
    }
}
