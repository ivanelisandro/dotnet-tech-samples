using System.Globalization;

namespace SampleAPI.Models;

/// <summary>
/// Provides methods to format products as strings.
/// </summary>
internal class ProductFormatter
{
    private static readonly string Separator = new('-', 20);

    /// <summary>
    /// Formats product information for showing in console.
    /// </summary>
    /// <param name="name">The name of the product.</param>
    /// <param name="category">The category of the product.</param>
    /// <param name="price">The price of the product in BRL.</param>
    /// <returns>The string formatted to show in console.</returns>
    internal static string Format(string name, string category, decimal price)
    {
        string formatted = string.Join(
            Environment.NewLine,
            Separator,
            name,
            category,
            $"R$ {price.ToString("F", CultureInfo.CurrentCulture)}",
            Separator);
        return formatted;
    }
}
