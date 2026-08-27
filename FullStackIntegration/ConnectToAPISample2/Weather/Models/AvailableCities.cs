using System.ComponentModel.DataAnnotations;

namespace ConnectToAPISample2.Weather.Models;

/// <summary>
/// A short list of cities with display names that I can use both for UI and in the query to retrieve info.
/// I left spaces between their numeric values so I can add more cities in the middle if I want.
/// </summary>
public enum AvailableCities
{
    [Display(Name = "Porto Alegre")]
    PortoAlegre = 1,

    [Display(Name = "São Paulo")]
    SaoPaulo = 10,

    [Display(Name = "Rio de Janeiro")]
    RioDeJaneiro = 11,

    [Display(Name = "London")]
    London = 100,

    [Display(Name = "New York")]
    NewYork = 200,
}