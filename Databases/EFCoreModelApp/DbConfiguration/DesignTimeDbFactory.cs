using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EFCoreModelApp.DbConfiguration;

/// <summary>
/// Provides a method to create a database context during design time.
/// Required for EF Tools to consistently resolve the configuration file when running the 'dotnet ef database update' command.
/// </summary>
public class DesignTimeDbFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    /// <summary>
    /// Creates an instance of <see cref="AppDbContext"/> by processing connection information from <see cref="IConfiguration"/>.
    /// Loads the configuration manually for design-time.
    /// </summary>
    /// <param name="args">Batch arguments. Unused.</param>
    public AppDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var dbFactory = new AppDbFactory();

        return dbFactory.Create(configuration);
    }
}