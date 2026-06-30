using EFCoreModelApp.DbConfiguration;
using EFCoreModelApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCoreModelApp;

/// <summary>
/// Class to run interactions with a database and view the results.
/// </summary>
internal class TestingDbAccess
{
    private readonly IConfiguration _configuration;
    private readonly AppDbFactory _dbFactory;

    /// <summary>
    /// Initializes a new instance of <see cref="TestingDbAccess"/>.
    /// </summary>
    public TestingDbAccess()
    {
        this._configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        this._dbFactory = new();
    }
    
    /// <summary>
    /// Reads employees from database and shows in the console output.
    /// </summary>
    internal void ShowAllEmployees()
    {
        using var context = this._dbFactory.Create(this._configuration);
        var allEmployees = context.Employees.Include(e => e.Department).ToList();

        Formatting.WriteHeader("All Employees:");

        foreach (var employee in allEmployees)
        {
            Console.WriteLine($"{employee.EmployeeID:D2}: {employee.FirstName} {employee.LastName} - {employee.Department?.Name ?? "N/A"}");
        }
    }

    /// <summary>
    /// Reads employees filtered by <paramref name="department"/> and shows in the console output.
    /// </summary>
    /// <param name="department">The department to filter.</param>
    internal void ShowEmployeesByDepartment(string department)
    {
        using var context = this._dbFactory.Create(this._configuration);
        var departmentEmployees = context.Employees
            .Include(e => e.Department)
            .Where(e => e.Department.Name == department)
            .ToList();

        Formatting.WriteHeader($"{department} Department Employees:");

        foreach (var employee in departmentEmployees)
        {
            Console.WriteLine($"{employee.EmployeeID:D2}: {employee.FirstName} {employee.LastName}");
        }
    }

    /// <summary>
    /// Adds an employee to the database.
    /// </summary>
    /// <param name="firstName">The first name of the employee.</param>
    /// <param name="lastName">The family name of the employee.</param>
    /// <param name="departmentId">The department for the employee.</param>
    internal void AddEmployee(string firstName, string lastName, int departmentId)
    {
        using var context = this._dbFactory.Create(this._configuration);
        var newEmployee = new Employee(firstName, lastName, DateTime.Now, departmentId);
        context.Employees.Add(newEmployee);
        context.SaveChanges();

        Formatting.WriteHeader($"New employee added. ID: {newEmployee.EmployeeID}");
    }

    /// <summary>
    /// Removes an employee from the database if it exists.
    /// </summary>
    /// <param name="id">The unique ID of the employee to remove.</param>
    internal void RemoveEmployee(int id)
    {
        using var context = this._dbFactory.Create(this._configuration);
        var employee = context.Employees.FirstOrDefault(e => e.EmployeeID == id);

        if (employee is null)
        {
            Formatting.WriteHeader("Not found.");
            return;
        }
        
        context.Employees.Remove(employee);
        context.SaveChanges();

        Formatting.WriteHeader($"Employee removed. ID: {employee.EmployeeID}");
    }

    /// <summary>
    /// Provides routines for creating standard way of formatting information in the console.
    /// </summary>
    private class Formatting
    {
        private static readonly string Separator = new('-', 40);

        /// <summary>
        /// Writes a header title with a separator for highlighting.
        /// </summary>
        /// <param name="title">The title text to write to the console.</param>
        internal static void WriteHeader(string title)
        {
            Console.WriteLine(Separator);
            Console.WriteLine(title);
            Console.WriteLine(Separator);
        }
    }
}
