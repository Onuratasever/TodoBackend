using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoBackend.Domain.Entities.Auth;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Persistence.Configurations;

public class AuthConfiguration : IEntityTypeConfiguration<Auth>
{
    public void Configure(EntityTypeBuilder<Auth> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.UserId).IsRequired();
        builder.Property(a => a.PasswordHash).IsRequired().HasMaxLength(200);
        builder.Property(a => a.PasswordSalt).IsRequired().HasMaxLength(200);

        // Foreign Key Configuration for User
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);  // Optional: Cascade delete
    }
}
