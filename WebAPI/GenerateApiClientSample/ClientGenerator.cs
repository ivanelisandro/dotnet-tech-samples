using NSwag;
using NSwag.CodeGeneration.CSharp;

namespace GenerateApiClientSample;

/// <summary>
/// Provides routine to generate API Client code that can be used in other modules to make calls to this API.
/// Uses the swagger.json file to determine the methods available and how to use them.
/// </summary>
public class ClientGenerator
{
    /// <summary>
    /// Decodes the swagger.json file representing the API and generates a class file with all available routes and methods.
    /// </summary>
    /// <returns>The result of the asynchronous operation.</returns>
    public async Task Run()
    {
        using var httpClient = new HttpClient();
        var swaggerJson = await httpClient.GetStringAsync("http://localhost:5063/swagger/v1/swagger.json");
        var document = await OpenApiDocument.FromJsonAsync(swaggerJson);

        // Configure the names we want for class and namespace.
        // Common convention is that class name and file name are the same.
        const string className = "UsersApiClient";
        var settings = new CSharpClientGeneratorSettings
        {
            ClassName = className,
            CSharpGeneratorSettings = { Namespace = "GenerateApiClientConsumer" }
        };

        var generator = new CSharpClientGenerator(document, settings);
        var code = generator.GenerateFile();

        await File.WriteAllTextAsync($"{className}.cs", code);
    }
}
