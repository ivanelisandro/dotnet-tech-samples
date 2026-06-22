namespace SampleAPI.Models;

/// <summary>
/// Represents product received in requests bodies to create or update products.
/// </summary>
/// <param name="name">The name of a product to process.</param>
/// <param name="category">The category of a product to process.</param>
/// <param name="price">The price (in BRL) of a product to process.</param>
public class ProductDto(string name, string category, decimal price)
{
    public string Name { get; set; } = name;

    public string Category { get; set; } = category;

    public decimal Price { get; set; } = price;
}
