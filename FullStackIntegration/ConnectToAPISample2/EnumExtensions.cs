using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ConnectToAPISample2;

/// <summary>
/// Adds extension methods to enums to handle <see cref="DisplayAttribute"/> usage.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Retrieves an attribute instance if existent in the enum value.
    /// </summary>
    /// <typeparam name="TAttribute">The type of attribute to retrieve.</typeparam>
    /// <param name="enumValue">The enum value of the current instance.</param>
    /// <returns>The expected attribute instance if it exists, null otherwise.</returns>
    public static TAttribute? GetAttribute<TAttribute>(this Enum enumValue)
            where TAttribute : Attribute
    {
        return enumValue
            .GetType()?
            .GetMember(enumValue.ToString())?
            .First()?
            .GetCustomAttribute<TAttribute>();
    }

    /// <summary>
    /// Retrieves the <see cref="DisplayAttribute.Name"/> value of a <see cref="DisplayAttribute"/> for a given enum.
    /// </summary>
    /// <param name="enumValue">The enum value of the current instance.</param>
    /// <returns>The user friendly text representing the enum if it exists, false otherwise.</returns>
    public static string DisplayName(this Enum enumValue)
    {
        return enumValue.GetAttribute<DisplayAttribute>()?.Name ?? string.Empty;
    }
}
