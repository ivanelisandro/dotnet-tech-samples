using System.ComponentModel.DataAnnotations;

namespace FormsSample.Models;

/// <summary>
/// Defines the structure of a feedback that can be included by an user.
/// </summary>
public class Feedback
{
    [Required(ErrorMessage = "Name cannot remain empty.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email cannot remain empty.")]
    [EmailAddress(ErrorMessage = "You must enter a valid email address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Comment cannot remain empty.")]
    [StringLength(500, MinimumLength = 5, ErrorMessage = "Comment can have between 5 and 500 characters.")]
    public string Comment { get; set; }
}
