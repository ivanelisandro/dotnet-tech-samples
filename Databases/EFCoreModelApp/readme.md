# EF Core Model App

This is a basic project simply demonstrating usage of the EF Core infrastructure with SQLite database.

Below I tried to describe configuration that I did when setting up the project, so it is easier to run it again if I clone this to a new destination.

## Initial configuration of this project

1. EF Core installed with the command:

    ```bash
    dotnet tool install --global dotnet-ef --version 9.0.16
    ```

2. External packages:
    - **Microsoft.EntityFrameworkCore.Sqlite**
    - **Microsoft.EntityFrameworkCore.Tools**
    - **Microsoft.Extensions.Configuration**
    - **Microsoft.Extensions.Configuration.Json**

## Settings configuration

1. Create `appsettings.json` with the template:

    ```json
    {
        "ConnectionStrings": {
            "DefaultConnection": "Data Source=SomeDatabaseName.db"
        }
    }
    ```

2. Set the correct connection string;

3. In `appsettings.json` Properties, set `Copy to Output Directory` to `Copy always`;

4. Ensure `appsettings.json` remains listed in `.gitignore`;


## Configuration after creating models

1. Creating migrations:

    ```bash
    dotnet ef migrations add InitialCreate
    ```

2. Applying migrations (this will create the `*.db` file directly in the output folder):

    ```bash
    dotnet ef database update
    ```

## Running the program

- Use an instance of `TestingDbAccess` to quickly setup information in `Program.cs` before running;
- Change the values when calling the methods to view different results;

### Objectives

- List all employees and their departments.
- Display employees filtering by department.
- To be able to add employees.
- To be able to remove employees.
