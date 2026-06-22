using Microsoft.AspNetCore.Mvc;
using SampleAPI.Models;

namespace SampleAPI.Controllers;

/// <summary>
/// Class to provide routes to handle products section.
/// </summary>
/// <param name="logger">An instance for handling logging information.</param>
[ApiController]
[Route("api/products")]
public class ProductsController(ILogger<ProductsController> logger) : ControllerBase
{
    /// <summary>
    /// A static list of products. For this sample we are just understanding how the routes are generated from Controller class,
    /// so the static list will be enough. We will look into databases later.
    /// </summary>
    private static readonly Dictionary<int, Product> products = new()
    {
        { 0, new Product(0, "Smartphone X200", "Mobile", 2499.90m) },
        { 1, new Product(1, "Laptop Pro 15", "Computers", 7899.00m) },
        { 2, new Product(2, "Wireless Headphones A7", "Audio", 599.99m) },
        { 3, new Product(3, "4K LED TV 55\"", "TV", 3299.50m) },
        { 4, new Product(4, "Bluetooth Speaker Mini", "Audio", 199.00m) },
        { 5, new Product(5, "Gaming Console Z", "Gaming", 3499.00m) },
        { 6, new Product(6, "Smartwatch FitBand 3", "Wearables", 899.90m) },
        { 7, new Product(7, "Mechanical Keyboard MX", "Accessories", 499.00m) },
        { 8, new Product(8, "USB-C Fast Charger 45W", "Accessories", 149.90m) },
        { 9, new Product(9, "Wi‑Fi 6 Router UltraLink", "Networking", 699.00m) },
        { 10, new Product(10, "Drone AirLite", "Drones", 2599.00m) },
    };

    /// <summary>
    /// A special product that will be listed in a separate route.
    /// </summary>
    private static readonly Product SpecialProduct = products[10];

    private readonly ILogger<ProductsController> logger = logger;

    /// <summary>
    /// Retrieves all products available.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<List<Product>> GetAll() => products.Values.ToList();

    /// <summary>
    /// Retrieves a product by its ID.
    /// </summary>
    /// <param name="id">The ID of a product.</param>
    /// <returns>The product information if the ID exists, otherwhise <see cref="NotFoundResult"/>.</returns>
    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        if (products.TryGetValue(id, out Product? product))
        {
            Console.WriteLine(product);
            return product;
        }

        return NotFound();
    }

    /// <summary>
    /// Retrieves a featured product, which can be changed every week, like a highlighted product or discount.
    /// </summary>
    /// <returns>The product information of the featured product of the week.</returns>
    [HttpGet("featured")]
    public Product GetFeaturedProduct() => SpecialProduct;

    /// <summary>
    /// Creates a product from information in the body of the request.
    /// </summary>
    /// <param name="productDto">The information of the product to create.</param>
    /// <returns>The product information if the product is created, otherwise <see cref="BadRequestResult"/>.</returns>
    [HttpPost]
    public ActionResult<Product> Create([FromBody] ProductDto productDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Simple ID calculation because our list is static. With a database this could be auto-generated.
        int nextId = products.Keys.Max() + 1;
        Product product = new(nextId, productDto.Name, productDto.Category, productDto.Price);

        products.Add(nextId, product);

        // Making use of the formatter to visualize the created product on console. A real API should use middleware instead.
        Console.WriteLine(product);

        return CreatedAtAction(
            nameof(Get),
            new { id = product.Id },
            product);
    }

    /// <summary>
    /// Updates product information for a given ID.
    /// </summary>
    /// <param name="id">The ID of a product.</param>
    /// <param name="productDto">The information of the product to update.</param>
    /// <returns><see cref="NoContentResult"/> if the product is updated, otherwise <see cref="NotFoundResult"/>.</returns>
    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] ProductDto productDto)
    {
        if (products.TryGetValue(id, out Product? product))
        {
            product.Update(productDto.Name, productDto.Category, productDto.Price);
            Console.WriteLine(product);

            return NoContent(); // PUT usually returns 204 No Content.
        }

        return NotFound();

    }

    /// <summary>
    /// Deletes a product for a given ID.
    /// </summary>
    /// <param name="id">The ID of a product.</param>
    /// <returns><see cref="NoContentResult"/> if the product is deleted, otherwise <see cref="NotFoundResult"/>.</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        if (products.ContainsKey(id))
        {
            products.Remove(id);
            Console.WriteLine($"Removed: {id}");

            return NoContent(); // Standard REST response for successful deletion.
        }

        return NotFound();
    }
}