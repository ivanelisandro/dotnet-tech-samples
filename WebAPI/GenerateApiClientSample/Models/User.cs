namespace GenerateApiClientSample.Models;

/// <summary>
/// Represents an user entity as stored internally.
/// </summary>
/// <param name="id">The unique ID to identify the user.</param>
/// <param name="name">The name of the user.</param>
public class User(int id, string name)
{
    public int Id { get; set; } = id;

    public string Name { get; set; } = name;
}
