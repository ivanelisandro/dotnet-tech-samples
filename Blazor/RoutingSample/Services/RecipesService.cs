using RoutingSample.Model;

namespace RoutingSample.Services;

/// <summary>
/// Provides access to recipes to be presented in the front-end.
/// Mocks behaviour of accessing an API or database to retrieve values.
/// </summary>
public class RecipesService
{
    /// <summary>
    /// Stores recipes to be presented.
    /// This is mocked behaviour. The values would usually either be retrieved from an API or read from a database.
    /// </summary>
    public Dictionary<int, Recipe> recipes = new()
    {
        { 1, new Recipe(1, "Spaghetti Carbonara", "Classic Italian pasta with eggs, cheese, pancetta, and black pepper.") },
        { 2, new Recipe(2, "Chicken Alfredo", "Creamy fettuccine pasta topped with seasoned grilled chicken.") },
        { 3, new Recipe(3, "Margherita Pizza", "Traditional pizza with fresh tomatoes, mozzarella, basil, and olive oil.") },
        { 4, new Recipe(4, "Garlic Butter Shrimp", "Sautéed shrimp in a rich garlic butter sauce with herbs.") },
        { 5, new Recipe(5, "Lemon Garlic Salmon", "Oven‑baked salmon seasoned with lemon, garlic, and herbs.") }
    };

    /// <summary>
    /// Event handler to notify object consuming the information when the list of recipes changes.
    /// </summary>
    public event Action? OnChange;

    /// <summary>
    /// Gets the information required from the recipes for a minimal presentation case.
    /// Avoids sharing the whole object when it is not necessary.
    /// </summary>
    /// <returns>A dictionary composed of the recipes identifiers and the recipes names.</returns>
    public Dictionary<int, string> GetAllStub()
    {
        return recipes.ToDictionary(item => item.Key, item => item.Value.Name);
    }

    /// <summary>
    /// Retrieves a single recipe object by ID.
    /// </summary>
    /// <param name="id">The unique ID of a recipe.</param>
    /// <returns>The recipe information if it exists, false otherwise.</returns>
    public Recipe? Get(int id)
    {
        if (recipes.TryGetValue(id, out Recipe? value))
        {
            return value;
        }

        return null;
    }

    /// <summary>
    /// Adds a recipe to the memory based on the information given by <paramref name="recipeToAdd"/>.
    /// </summary>
    /// <param name="recipeToAdd">The object containig the information to add.</param>
    public void Add(RecipeDto recipeToAdd)
    {
        if (string.IsNullOrWhiteSpace(recipeToAdd.Name) || string.IsNullOrWhiteSpace(recipeToAdd.Description))
        {
            return;
        }

        // Mock adding just for the UI. Usually this would be calling an API.
        int id = recipes.Keys.Max() + 1;
        var recipe = new Recipe(id, recipeToAdd.Name, recipeToAdd.Description);
        recipes.Add(id, recipe);
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
