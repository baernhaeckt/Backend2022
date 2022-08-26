namespace MixMeal.Core.Models;

public record Ingredient(string Name, double Calories, double Carbohydrates, double Fat, IReadOnlyCollection<DishType> ValidDishTypes)
{
    /// <summary>
    ///     Defines for which <see cref="DishType"/> this <see cref="Ingredient"/> can be used for to create a
    ///     <see cref="Dish"/>.
    /// </summary>
    public IReadOnlyCollection<DishType> ValidDishTypes { get; } = ValidDishTypes;
}