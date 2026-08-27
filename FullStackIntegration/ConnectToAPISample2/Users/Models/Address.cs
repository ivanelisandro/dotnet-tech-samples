namespace ConnectToAPISample2.Users.Models;

/// <summary>
/// Represents address from an user as retrieved from a placeholder API.
/// </summary>
public class Address
{
    public required string Street { get; set; }

    public required string Suite { get; set; }

    public required string City { get; set; }

    public required string Zipcode { get; set; }
}
