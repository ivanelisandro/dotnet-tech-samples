using CRUDWithMySQL.Models;
using Microsoft.Extensions.Configuration;

namespace CRUDWithMySQL;

/// <summary>
/// Provides routines to test interaction with the database.
/// </summary>
internal class TestingDatabase
{
    private readonly IConfiguration _configuration;

    public TestingDatabase()
    {
        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        new DbSeeder(_configuration).InitializeIfEmpty();
    }

    /// <summary>
    /// Creates a product and inserts in the database.
    /// </summary>
    /// <param name="name">The name of the product to create.</param>
    /// <param name="price">The price of the product to create.</param>
    /// <returns>The ID of the new product.</returns>
    internal int Create(string name, decimal price)
    {
        using ApplicationDbContext context = new(_configuration);

        Product newProduct = new(name, price);
        context.Products.Add(newProduct);
        context.SaveChanges();

        return newProduct.Id;
    }

    /// <summary>
    /// Reads all products from the database and writes to the console output.
    /// </summary>
    /// <param name="headerText">A text to appear as header before the products list.</param>
    internal void ReadAll(string headerText)
    {
        using ApplicationDbContext context = new(_configuration);
        var allProducts = context.Products.ToList();

        Formatting.WriteHeader(headerText);

        const int TablePadding = 34;
        allProducts.ForEach(p => Console.WriteLine($"{p.Id}: {p.ToString(TablePadding)}"));
    }

    /// <summary>
    /// Reads a single product from the database given a <paramref name="productId"/>.
    /// </summary>
    /// <param name="productId">The unique ID of a product.</param>
    internal void Read(int productId)
    {
        using ApplicationDbContext context = new(_configuration);
        var product = context.Products.Find(productId);

        if (product is null)
        {
            ReportNotFound();
            return;
        }

        Formatting.WriteHeader($"Product Found: {product}");
    }

    /// <summary>
    /// Updates the price of a product if it exists with the given <paramref name="newPrice"/>.
    /// </summary>
    /// <param name="productId">The unique ID of a product to update.</param>
    /// <param name="newPrice">The new value of price for the product.</param>
    internal void Update(int productId, decimal newPrice)
    {
        using ApplicationDbContext context = new(_configuration);

        var productToUpdate = context.Products.Find(productId);
        if (productToUpdate is null)
        {
            ReportNotFound();
            return;
        }

        productToUpdate.Price = newPrice;
        context.SaveChanges();
    }

    /// <summary>
    /// Deletes a product if it exists by the given <paramref name="productId"/>.
    /// </summary>
    /// <param name="productId">The unique ID of a product to delete.</param>
    internal void Delete(int productId)
    {
        using ApplicationDbContext context = new(_configuration);

        var productToDelete = context.Products.Find(productId);
        if (productToDelete is null)
        {
            ReportNotFound();
            return;
        }

        context.Products.Remove(productToDelete);
        context.SaveChanges();
    }

    /// <summary>
    /// Writes a message to console ouput reporting a product was not found.
    /// </summary>
    private static void ReportNotFound()
    {
        Formatting.WriteHeader("Product not found.");
    }

    /// <summary>
    /// Provides routines for creating standard way of formatting information in the console.
    /// </summary>
    private class Formatting
    {
        private static readonly string Separator = new('-', 50);

        /// <summary>
        /// Writes a header title with a separator for highlighting.
        /// </summary>
        /// <param name="title">The title text to write to the console.</param>
        internal static void WriteHeader(string title)
        {
            Console.WriteLine(Separator);
            Console.WriteLine(title);
            Console.WriteLine(Separator);
        }
    }

    /// <summary>
    /// Provides routine to initialize database with a few items if the database is empty.
    /// </summary>
    /// <param name="configuration">The configuration object from where to extract connection information.</param>
    private class DbSeeder(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;

        /// <summary>
        /// Holds a list of products that will be used to populate the database only once if it is empty.
        /// </summary>
        private readonly List<Product> _initialProducts =
        [
            new("Gaming Laptop X15", 7499.99m),
            new("Mechanical Keyboard Pro", 499.90m),
            new("Wireless Ergonomic Mouse", 289.50m),
            new("4K UltraWide Monitor 34\"", 3299.00m),
            new("Noise-Cancelling Headphones", 1299.99m),
            new("Portable SSD 1TB", 599.00m),
            new("USB-C Docking Station", 349.90m),
            new("Smartwatch Series 8", 2199.00m),
            new("Bluetooth Speaker Mini", 199.99m),
            new("VR Headset Explorer", 3999.00m),
            new("Graphics Card RTX 4080", 8999.00m),
            new("Gaming Chair Elite", 1599.00m),
            new("Wi-Fi 6 Router Turbo", 699.00m),
            new("Laser Printer Compact", 899.90m),
            new("Noise-Cancelling Earbuds", 799.00m),
            new("Smart Home Hub", 499.00m),
            new("External Monitor Light Bar", 249.90m),
            new("Portable Power Bank 20,000mAh", 299.00m)
        ];

        /// <summary>
        /// Inserts a standard list of items in the database only if it is empty.
        /// </summary>
        internal void InitializeIfEmpty()
        {
            using ApplicationDbContext context = new(_configuration);

            if (context.Products.Any())
            {
                return;
            }

            foreach (var product in _initialProducts)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}
