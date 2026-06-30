# CRUD with MySQL

This is a basic project simply demonstrating a CRUD with MySQL database.

Below I tried to describe configuration that I did when setting up the project, so it is easier to run it again if I clone this to a new destination.

## Initial configuration of this project

1. EF Core installed with the command:

    ```bash
    dotnet tool install --global dotnet-ef --version 9.0.16
    ```

2. External packages:
    - **Pomelo.EntityFrameworkCore.MySql**
    - **Microsoft.EntityFrameworkCore.Tools**
    - **Microsoft.Extensions.Configuration**
    - **Microsoft.Extensions.Configuration.Json**

3. Access MySQL CLI and create database:

    - Enter the password when prompted.
    - Run the command for creating a database:

        ```sql
        CREATE DATABASE InsertYourOwnDatabaseNameHere;
        ```


## Settings configuration

1. Create `appsettings.json` with the template:

    ```json
    {
        "ConnectionStrings": {
            "DefaultConnection": "Server=localhost;Database=InsertYourOwnDatabaseNameHere;User=root;Password=SomeSuperSecretAndSecurePasswordYouChoseGoesHere;"
        }
    }
    ```

2. Set the correct connection string;

3. In `appsettings.json` Properties, set `Copy to Output Directory` to `Copy always`;

4. Ensure `appsettings.json` remains listed in `.gitignore`;

5. In `ApplicationDbContext`, when overriding `OnConfiguring`:

    - Set correct version configuration using `MySqlServerVersion`.
    - This must match the MySQL version that is installed in the machine.


## Configuration after creating models

1. Creating migrations:

    ```bash
    dotnet ef migrations add InitialCreate
    ```

2. Applying migrations:

    ```bash
    dotnet ef database update
    ```

## Running the program

- Use an instance of `TestingDatabase` to setup information in `Program.cs` before running;
- Change the values when calling the methods to view different results;

### Objectives

- Create a product.
- List all products.
- Read one product.
- Update one product and view the updated value.
- Delete one product and view the updated list of products.
