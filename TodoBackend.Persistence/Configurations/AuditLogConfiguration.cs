using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoBackend.Domain.Entities.AuditLog;
using TodoBackend.Domain.Entities.User;

namespace TodoBackend.Persistence.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.HasKey(al => al.Id);
        builder.Property(al => al.UserId).IsRequired();
        builder.Property(al => al.Action).IsRequired().HasMaxLength(500);
        builder.Property(al => al.ChangeDateTime).IsRequired();

        // Foreign Key Configuration for User
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(al => al.UserId)
            .OnDelete(DeleteBehavior.Cascade);  // Optional: Cascade delete
    }
}
