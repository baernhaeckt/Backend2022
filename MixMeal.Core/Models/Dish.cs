namespace MixMeal.Core.Models;

public record Dish(DishType DishType, DishSize DishSize, IReadOnlyCollection<Ingredient> Ingredients, string? Name = null)
{
    public string Name { get; init; } = Name ?? Guid.NewGuid().ToString();

    /// <summary>
    ///     Defines the amount of <see cref="Ingredient"/>s valid for this <see cref="Dish"/>.
    /// </summary>
    public DishSize DishSize { get; } = DishSize;

    /// <summary>
    ///     <see cref="Ingredient"/> in the Meal.
    /// </summary>
    public IReadOnlyCollection<Ingredient> Ingredients { get; } = Ingredients;
}