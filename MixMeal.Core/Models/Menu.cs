namespace MixMeal.Core.Models;

public class Menu : NutritionalValues
{
    public IReadOnlyCollection<Dish> Dishes { get; set; }

    public string? Name { get; set; }

    private int? _id;
    public int Id
    {
        get { return _id ??= GetHashCode(); }
        set { _id = value; }
    }

    public override int GetHashCode()
        => string.Concat(Dishes.Select(d => d.Id)).GetHashCode();
}