namespace CRUDWithMySQL.Models;

/// <summary>
/// Represents a product in the database.
/// </summary>
/// <param name="name">The name of the product.</param>
/// <param name="price">The price of the product.</param>
public class Product(string name, decimal price)
{
    /// <summary>
    /// Gets or sets the ID.
    /// Used as primary key.
    /// </summary>
    public int Id { get; set; }

    public string Name { get; set; } = name;

    public decimal Price { get; set; } = price;

    /// <summary>
    /// Formats the object into text format.
    /// </summary>
    /// <returns>A text containing the name and price of the object.</returns>
    public override string ToString()
    {
        return this.ToString(0);
    }

    /// <summary>
    /// Formats the object into text format, with <paramref name="rightPadding"/> for a table-like appearence.
    /// </summary>
    /// <param name="rightPadding">The value of padding used on the right side of the <see cref="Name"/>.</param>
    /// <returns>A text containing the name and price of the object.</returns>
    public string ToString(int rightPadding)
    {
        return $"{this.Name.PadRight(rightPadding)} - $ {this.Price,7:F2}";
    }
}
