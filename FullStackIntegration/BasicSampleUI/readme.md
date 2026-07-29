# Basic Sample UI

This project sets up a very simple Blazor frontend that will consume the `BasicSampleAPI` project.

The purpose is to demonstrate connection between frontend and backend.

Despite being simple, local configuration is not commited with the source code. So some configuration is required before running this project if cloning from scratch.

## Local configuration for Blazor WebAssembly

You need a configuration file from where we read the information to connect to the backend.

Blazor WebAssembly does **not** load User Secrets or server-side `appsettings.json`.

Configuration must be provided through a file that the browser can download.

### Add configuration to `wwwroot/appsettings.json`

- Create the file: `wwwroot/appsettings.json`
- Add configuration to connect to the API (set ports accordingly):

    ```json
    {
      "Api": {
        "BaseUrl": "https://localhost:5001",
        "BaseUrlSecure": "https://localhost:7001",
        "Endpoints": {
          "Products": "products"
        }
      }
    }
    ```
