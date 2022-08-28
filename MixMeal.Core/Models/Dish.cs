namespace MixMeal.Core.Models;

public class Dish : NutritionalValues
{
    public string Name { get; init; } = string.Empty;

    public DishType DishType { get; set; }

    /// <summary>
    ///     Defines the amount of <see cref="Ingredient"/>s valid for this <see cref="Dish"/>.
    /// </summary>
    [Obsolete(message: "can be evaluated by counting Ingredients")]
    public DishSize DishSize { get; init; }

    /// <summary>
    ///     <see cref="Ingredient"/> in the Meal.
    /// </summary>
    public IReadOnlyCollection<Ingredient> Ingredients { get; set; }

    public int Id
    {
        get => GetHashCode();
        set { }
    }

    /// <summary>
    ///     <see cref="Dish"/> with the same Ingredients should be handled as identical.
    /// </summary>
    public override int GetHashCode()
        => (string.Concat(Ingredients.OrderBy(i => i.Name).Select(i => i.Name)) + DishType.ToString())
        .GetHashCode();
}