namespace ExplicitRouting;

/// <summary>
/// Provides routines to use with the '/users' route.
/// Does not actually handle any users updates.
/// This is just intended to map and understand the routes and http methods.
/// </summary>
public class Users
{
    /// <summary>
    /// Retrieves the content for when all users are requested.
    /// </summary>
    /// <returns>All users text.</returns>
    public static string GetAll()
    {
        return "Hello, Users!";
    }

    /// <summary>
    /// Retrieves the content for user request by ID.
    /// </summary>
    /// <param name="id">The ID of an user extracted from the route.</param>
    /// <returns>The content for a given user.</returns>
    public static Task<string> Get(int id)
    {
        return Task.FromResult($"User ID: {id}");
    }

    /// <summary>
    /// Simulates the result of adding an user.
    /// Does not actually create any resource.
    /// </summary>
    /// <returns>The text for user added.</returns>
    public static string Post()
    {
        return "User added!";
    }

    /// <summary>
    /// Simulates updating an user by ID.
    /// Does not actually update any resource.
    /// </summary>
    /// <param name="id">The ID of an user extracted from the route.</param>
    /// <returns>The content for the updated user.</returns>
    public static Task<string> Put(int id)
    {
        return Task.FromResult($"User updated: {id}");
    }

    /// <summary>
    /// Simulates deleting an user by ID.
    /// Does not actually delete any resource.
    /// </summary>
    /// <param name="id">The ID of an user extracted from the route.</param>
    /// <returns>The content for the deleted user.</returns>
    public static Task<string> Delete(int id)
    {
        return Task.FromResult($"User deleted: {id}");
    }
}
