using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CRUDWithMySQL.Models;

/// <summary>
/// Provides data persistency structures.
/// </summary>
/// <param name="configuration">The configuration object from where to extract connection information.</param>
public class ApplicationDbContext(IConfiguration configuration) : DbContext
{
    private readonly IConfiguration _configuration = configuration;

    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Configures the database to be used for this context.
    /// This method is called for each instance of the context that is created.
    /// </summary>
    /// <param name="optionsBuilder">A builder used to configure the context.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Setup database.
        // Ensure MySQL version is matching installed version.
        optionsBuilder.UseMySql(
            _configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 46)));
    }
}
