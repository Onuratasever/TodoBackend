using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using TodoBackend.Persistence.Configurations;

namespace TodoBackend.Persistence;

public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(Configuration.ConfigurationString,
            optionsBuilder => optionsBuilder.EnableRetryOnFailure());

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}