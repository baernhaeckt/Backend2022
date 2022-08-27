namespace MixMeal.Core.Models;

public record Menu(IReadOnlyCollection<Dish> Dishes, string? Name = null)
{
    public IReadOnlyCollection<Dish> Dishes { get; } = Dishes;
}