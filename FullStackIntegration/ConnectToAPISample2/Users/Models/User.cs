namespace ConnectToAPISample2.Users.Models;

/// <summary>
/// Represents user data as retrieved from a placeholder API.
/// </summary>
public class User
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required Address Address { get; set; }
}
