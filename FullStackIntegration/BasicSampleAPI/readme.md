# Basic Sample API

This project sets up a very simple API with one endpoint.

The purpose is to demonstrate connection between frontend and backend.

Despite being simple, local configuration is not commited with the source code. So some configuration is required before running this project if cloning from scratch.

## Local configuration for the API

Configure User Secrets after cloning the project using one of the options provided.

### Option 1: User Secrets JSON

- Right click the project in the solution treeview;
- Select `Manage User Secrets`;
- Add the configuration to run the project locally (set the ports accordingly):

    ```json
    {
        "Cors": {
            "AllowedOrigins": [
                "https://localhost:7001",
                "http://localhost:5001"
            ]
        }
    }
    ```

### Option 2: Developer PowerShell commands

- Run these commands inside the API project directory (set the ports accordingly):

    ```bash
    dotnet user-secrets set "Cors:AllowedOrigins:0" "https://localhost:7001"
    dotnet user-secrets set "Cors:AllowedOrigins:1" "http://localhost:5001"
    ```
