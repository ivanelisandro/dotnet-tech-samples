namespace EFCoreModelApp.Models;

/// <summary>
/// Represents an employee in the database.
/// </summary>
/// <param name="firstName">The first name of the employee.</param>
/// <param name="lastName">The family name of the employee.</param>
/// <param name="hireDate">The date the employee started working.</param>
/// <param name="departmentID">The department the employee works on.</param>
public class Employee(string firstName, string lastName, DateTime hireDate, int departmentID)
{
    public Employee(int id, string firstName, string lastName, DateTime hireDate, int departmentID)
        : this(firstName, lastName, hireDate, departmentID)
    {
        this.EmployeeID = id;
    }

    /// <summary>
    /// Gets or sets the ID.
    /// Used as primary key.
    /// </summary>
    public int EmployeeID { get; set; }

    public string FirstName { get; set; } = firstName;
    
    public string LastName { get; set; } = lastName;

    public DateTime HireDate { get; set; } = hireDate;

    /// <summary>
    /// Gets or sets the Department ID.
    /// Used as foreign key for retrieving department information.
    /// </summary>
    public int DepartmentID { get; set; } = departmentID;

    /// <summary>
    /// Gets or sets the Department information.
    /// Navigation Property for the related table.
    /// </summary>
    public Department Department { get; set; }
}
