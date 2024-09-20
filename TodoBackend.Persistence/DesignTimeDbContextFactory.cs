using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TodoBackend.Persistence;

public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server=DESKTOP-K1K3TFG\\SQLEXPRESS;Database=TodoDb;TrustServerCertificate=true;Trusted_Connection=True;",
            optionsBuilder => optionsBuilder.EnableRetryOnFailure());

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}