using EFCoreModelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreModelApp.DbConfiguration;

/// <summary>
/// Provides data persistency structures.
/// </summary>
public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Department> Departments { get; set; }

    /// <summary>
    /// Defines database relationships and seeds initial data.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define the relationships between Employee and Department.
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentID);
        });

        // Initializing departments with data.
        modelBuilder.Entity<Department>().HasData(
            new Department(1, "HR"),
            new Department(2, "Engineering"),
            new Department(3, "Finance"),
            new Department(4, "Marketing")
        );

        // Initializing employees with data.
        modelBuilder.Entity<Employee>().HasData(
            new Employee(1, "Rafael", "Carvalho", DateTime.Now, 1),
            new Employee(2, "Larissa", "Gomes", DateTime.Now, 1),
            new Employee(3, "Maria", "Oliveira", DateTime.Now, 2),
            new Employee(4, "Pedro", "Santos", DateTime.Now, 2),
            new Employee(5, "Mariana", "Costa", DateTime.Now, 2),
            new Employee(6, "João", "Silva", DateTime.Now, 3),
            new Employee(7, "Beatriz", "Almeida", DateTime.Now, 4),
            new Employee(8, "Gabriel", "Rodrigues", DateTime.Now, 4)
        );
    }
}
