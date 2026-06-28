using GenerateApiClientSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenerateApiClientSample.Controllers;

/// <summary>
/// Provides routes for dealing with user information.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    /// <summary>
    /// Stores a dictionary of users.
    /// This is just to demonstrate the generated client accessing the values and methods
    /// so an in memory dictionary is enough for us to observe the behaviour.
    /// In a real API these values would be read from a database.
    /// </summary>
    private static Dictionary<int, User> _users = new()
    {
        { 1,  new User(1, "João Silva") },
        { 2,  new User(2, "Maria Oliveira") },
        { 3,  new User(3, "Pedro Santos") },
        { 4,  new User(4, "Ana Souza") },
        { 5,  new User(5, "Lucas Pereira") },
        { 6,  new User(6, "Mariana Costa") },
        { 7,  new User(7, "Gabriel Rodrigues") },
        { 8,  new User(8, "Beatriz Almeida") },
        { 9,  new User(9, "Rafael Carvalho") },
        { 10, new User(10, "Camila Fernandes") },
        { 11, new User(11, "Gustavo Ribeiro") },
        { 12, new User(12, "Larissa Gomes") }
    };

    /// <summary>
    /// Retrieves all users currently available.
    /// </summary>
    /// <returns>A list of all users.</returns>
    [HttpGet]
    [Produces("application/json")]
    public ActionResult<List<User>> GetAll()
    {
        return _users.Values.ToList();
    }

    /// <summary>
    /// Retrieves an user by ID.
    /// </summary>
    /// <param name="id">The ID of the user to retrieve.</param>
    /// <returns>The user details if found, otherwise <see cref="NotFoundResult">.</returns>
    [HttpGet("{id}")]
    [Produces("application/json")]
    public ActionResult<User> GetUser(int id)
    {
        if (_users.TryGetValue(id, out User? user) &&
            user is not null)
        {
            return Ok(user);
        }

        return NotFound();
    }

    /// <summary>
    /// Adds an user based on the information contained in <paramref name="userDto"/>.
    /// </summary>
    /// <param name="userDto">The details about the user to add.</param>
    /// <returns>Information about the added user.</returns>
    [HttpPost]
    [Produces("application/json")]
    public ActionResult<User> AddUser(UserDto userDto)
    {
        var newId = _users.Keys.Count == 0 ?
            1 :
            _users.Keys.Max() + 1;

        var user = new User(newId, userDto.Name);
        _users.Add(newId, user);

        return CreatedAtAction(nameof(GetUser), new { id = newId }, user);
    }

    /// <summary>
    /// Updates an user based on the information contained in <paramref name="userDto"/>.
    /// </summary>
    /// <param name="id">The ID of the user for which to update information.</param>
    /// <param name="userDto">The details about the user to update.</param>
    /// <returns>Information about the updated user if found, otherwise <see cref="NotFoundResult"/>.</returns>
    [HttpPut("{id}")]
    [Produces("application/json")]
    public ActionResult<User> UpdateUser(int id, UserDto userDto)
    {
        if (!_users.ContainsKey(id))
        {
            return NotFound("User not found.");
        }

        var updatedUser = new User(id, userDto.Name);
        _users[id] = updatedUser;

        return Ok(updatedUser);
    }

    /// <summary>
    /// Deletes an user by a given <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the user to delete.</param>
    /// <returns><see cref="NoContentResult"/> if the user existed to be deleted, otherwise <see cref="NotFoundResult"/>.</returns>
    [HttpDelete("{id}")]
    [Produces("application/json")]
    public ActionResult DeleteUser(int id)
    {
        if (!_users.ContainsKey(id))
        {
            return NotFound("User not found.");
        }

        _users.Remove(id);
        return NoContent();
    }
}
