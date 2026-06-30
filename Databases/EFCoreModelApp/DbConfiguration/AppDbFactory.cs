using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace EFCoreModelApp.DbConfiguration;

/// <summary>
/// Provides a method to create a database context for the application.
/// </summary>
public class AppDbFactory
{
    /// <summary>
    /// Creates an instance of <see cref="AppDbContext"/> by processing connection information from the <paramref name="configuration"/>.
    /// Configures the database and options to be used for the context.
    /// </summary>
    /// <param name="configuration">The configuration to extract connection information.</param>
    public AppDbContext Create(IConfiguration configuration)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        // Get connection string from configuration.
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var sqliteBuilder = new SqliteConnectionStringBuilder(connectionString);

        if (!Path.IsPathRooted(sqliteBuilder.DataSource))
        {
            // Redirect database file to output directory.
            sqliteBuilder.DataSource = Path.Combine(AppContext.BaseDirectory, sqliteBuilder.DataSource);
        }

        // Setup database.
        optionsBuilder
            .UseSqlite(sqliteBuilder.ToString())
            .ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning)
            );

        return new AppDbContext(optionsBuilder.Options);
    }
}