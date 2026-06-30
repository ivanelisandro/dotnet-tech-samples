using EFCoreModelApp;

TestingDbAccess dbAccess = new();

dbAccess.ShowAllEmployees();
dbAccess.ShowEmployeesByDepartment("HR");

// For testing adding
// Name suggestions: Ana Souza, Lucas Pereira, Camila Fernandes, Gustavo Ribeiro.
dbAccess.AddEmployee("Ana", "Souza", 2);
dbAccess.AddEmployee("Camila", "Fernandes", 3);

// For testing remove
// dbAccess.RemoveEmployee(13);
// dbAccess.RemoveEmployee(14);

// Show all again to view added employee.
dbAccess.ShowAllEmployees();

dbAccess.ShowEmployeesByDepartment("Engineering");
dbAccess.ShowEmployeesByDepartment("Finance");

Console.ReadLine();
