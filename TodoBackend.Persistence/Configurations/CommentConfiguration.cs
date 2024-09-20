using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoBackend.Domain.Entities.Comment;
using TodoBackend.Domain.Entities.TodoItem;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Persistence.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.TodoId).IsRequired();
        builder.Property(c => c.Content).IsRequired().HasMaxLength(1000);
        builder.Property(c => c.UserId).IsRequired();

        // Foreign Key Configuration for TodoItem
        builder.HasOne<TodoItem>()
            .WithMany()
            .HasForeignKey(c => c.TodoId)
            .OnDelete(DeleteBehavior.Cascade);  // Optional: Cascade delete

        // Foreign Key Configuration for User
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction);  // No action for User

        builder.Property(c => c.CreatedAt).IsRequired();
        builder.Property(c => c.UpdatedAt).IsRequired();
    }
}
