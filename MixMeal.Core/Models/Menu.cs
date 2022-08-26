namespace MixMeal.Core.Models;

public record Menu(IReadOnlyCollection<Dish> Dishes)
{
    public IReadOnlyCollection<Dish> Dishes { get; } = Dishes;
}