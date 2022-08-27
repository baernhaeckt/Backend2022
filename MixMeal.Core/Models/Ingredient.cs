namespace MixMeal.Core.Models;

public class Ingredient
{
    public string Name { get; init; }

    public string Icon { get; init; }

    public double Calories { get; init; }

    public double Carbohydrates { get; init; }

    public double Fat { get; init; }

    public bool Premium { get; set; } = false;

    /// <summary>
    ///     Defines for which <see cref="DishType"/> this <see cref="Ingredient"/> can be used for to create a
    ///     <see cref="Dish"/>.
    /// </summary>
    public IReadOnlyCollection<DishType> ValidDishTypes { get; init; }
}