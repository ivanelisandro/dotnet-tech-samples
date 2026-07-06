namespace RoutingSample.Model;

/// <summary>
/// Represents recipe information as stored by the application.
/// </summary>
/// <param name="id">The unique identifier of the recipe.</param>
/// <param name="name">A name for the recipe.</param>
/// <param name="description">A user-friendly description for the recipe.</param>
public class Recipe(int id, string name, string description)
{
    public int Id { get; set; } = id;

    public string Name { get; set; } = name;

    public string Description { get; set; } = description;
}
