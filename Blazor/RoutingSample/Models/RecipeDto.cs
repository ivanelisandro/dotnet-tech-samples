using System.ComponentModel.DataAnnotations;

namespace RoutingSample.Models;

/// <summary>
/// Represents recipe information entered by the user, with input validation.
/// </summary>
public class RecipeDto
{
    [Required(ErrorMessage = "Recipe name cannot be empty")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description cannot be empty")]
    public string Description { get; set; }
}
