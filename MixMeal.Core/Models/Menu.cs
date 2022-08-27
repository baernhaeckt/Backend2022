namespace MixMeal.Core.Models;

public class Menu : NutritionalValues
{
    public IReadOnlyCollection<Dish> Dishes { get; set; }

    public string? Name { get; set; }

    public int Id
    {
        get => GetHashCode();
        set { }
    }

    public override int GetHashCode()
        => string.Concat(Dishes.Select(d => d.Id)).GetHashCode();
}