namespace MixMeal.Core.Models;

public class Menu
{
    public IReadOnlyCollection<Dish> Dishes { get; set; }

    public string? Name { get; set; }
}