using Microsoft.AspNetCore.Mvc;

namespace LoggingSample.Controllers;

/// <summary>
/// Provides route to exemplify exception handling.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ErrorHandlingController : ControllerBase
{
    /// <summary>
    /// Provides a division operation route that allows you to generate a <see cref="DivideByZeroException"/>.
    /// Used to demonstrante exception handling and how it will be logged into the system.
    /// </summary>
    /// <param name="numerator">The numerator for a division operation.</param>
    /// <param name="denominator">The denominator for a division operation.</param>
    /// <returns>The result if the numbers are valid, <see cref="BadRequestResult"/> if 0 is used in the denominator.</returns>
    [HttpGet("division")]
    public IActionResult GetDivisionResult(int numerator, int denominator)
    {
        try
        {
            var result = numerator / denominator;
            return Ok(result);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
            return BadRequest("Cannot divide by zero.");
        }
    }

    /// <summary>
    /// Provides a route that simulates an unhandled exception which will be caught by the global exception handling middleware.
    /// </summary>
    /// <returns>Nothing. Always generates the exception.</returns>
    /// <exception cref="InvalidOperationException">Forced exception to simulate behavior.</exception>
    [HttpGet("throw-global")]
    public IActionResult SimulateInvalidOperation()
    {
        throw new InvalidOperationException("Mocked failure");
    }
}
