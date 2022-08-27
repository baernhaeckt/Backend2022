namespace MixMeal.Core.Models;

public class Dish
{
    public string Name { get; init; }

    public DishType DishType { get; set; }

    /// <summary>
    ///     Defines the amount of <see cref="Ingredient"/>s valid for this <see cref="Dish"/>.
    /// </summary>
    public DishSize DishSize { get; init; }

    /// <summary>
    ///     <see cref="Ingredient"/> in the Meal.
    /// </summary>
    public IReadOnlyCollection<Ingredient> Ingredients { get; init; }
}