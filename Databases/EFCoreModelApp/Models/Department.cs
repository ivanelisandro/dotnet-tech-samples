namespace EFCoreModelApp.Models;

/// <summary>
/// Represents a department in the database.
/// </summary>
/// <param name="id">The unique ID of the department.</param>
/// <param name="name">The name of the department.</param>
public class Department(int id, string name)
{
    /// <summary>
    /// Initializes a new instance of <see cref="Department"/>.
    /// Constructor required when we are using department in filters.
    /// </summary>
    public Department()
        : this(0, string.Empty)
    {
    }

    /// <summary>
    /// Gets or sets the ID.
    /// Used as primary key.
    /// </summary>
    public int DepartmentID { get; set; } = id;

    public string Name { get; set; } = name;

    /// <summary>
    /// Gets or sets the employees linked to this department.
    /// Navigation Property for the related table.
    /// </summary>
    public List<Employee> Employees { get; set; }
}
