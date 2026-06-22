namespace SampleAPI.Models;

/// <summary>
/// Represents a product saved in the application.
/// </summary>
/// <param name="id">The ID of the product. Must be unique.</param>
/// <param name="name">The name of the product.</param>
/// <param name="category">The category of the product.</param>
/// <param name="price">The price of the product in BRL.</param>
public class Product(int id, string name, string category, decimal price)
{
    public int Id { get; } = id;

    public string Name { get; private set; } = name;

    public string Category { get; private set; } = category;

    public decimal Price { get; private set; } = price;

    /// <summary>
    /// Updates the product information.
    /// </summary>
    /// <param name="name">The name of the product.</param>
    /// <param name="category">The category of the product.</param>
    /// <param name="price">The price of the product in BRL.</param>
    internal void Update(string name, string category, decimal price)
    {
        this.Name = name;
        this.Category = category;
        this.Price = price;
    }

    /// <summary>
    /// Converts the product information to a formatted string.
    /// </summary>
    /// <returns>The product information as a formatted string.</returns>
    public override string ToString()
    {
        return ProductFormatter.Format(this.Name, this.Category, this.Price);
    }
}
