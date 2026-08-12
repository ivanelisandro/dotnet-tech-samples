# Connect to API Sample 2

This project sets up a Blazor frontend that consumes an external Weather API.

To use this API it is necessary to:

1. Access https://www.weatherapi.com/
2. Register for free or login to your account
3. Generate your API key

Local configuration is not commited with the source code. Some configuration is required before running this project if cloning from scratch.

## Local configuration for Blazor WebAssembly

You need a configuration file from where we read the information to connect to the Weather API.

Blazor WebAssembly does **not** load User Secrets or server-side `appsettings.json`.

Configuration must be provided through a file that the browser can download.

### Add configuration to `wwwroot/appsettings.json`

- Create the file: `wwwroot/appsettings.json`
- Add configuration to connect to the API (place your API key where it is indicated):

    ```json
    {
      "Api": {
        "BaseAddress": "https://api.weatherapi.com/v1/current.json?key=your_api_key_goes_here"
      }
    }
    ```
