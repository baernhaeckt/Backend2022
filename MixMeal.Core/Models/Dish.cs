using System.Text.Json.Serialization;

namespace MixMeal.Core.Models;

public class Dish : NutritionalValues
{
    private string _name;

    public string Name 
    { 
        get
        {
            return _name ??= GenerateName();
        }
        init
        { 
            _name = value; 
        }
    }

    private string GenerateName()
    {
        return string.Join(" ", Ingredients.Select(i => i.Name));
    }

    public DishType DishType { get; set; }

    /// <summary>
    ///     Defines the amount of <see cref="Ingredient"/>s valid for this <see cref="Dish"/>.
    /// </summary>
    [Obsolete(message: "can be evaluated by counting Ingredients")]
    public DishSize DishSize { get; init; }

    /// <summary>
    ///     <see cref="Ingredient"/> in the Meal.
    /// </summary>
    public IReadOnlyCollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    [JsonIgnore]
    public IReadOnlyCollection<Menu> UsedIn { get; set; } = new List<Menu>();

    private int? _id;
    public int Id
    {
        get { return _id ??= GetHashCode(); }
        set { _id = value; }
    }

    /// <summary>
    ///     <see cref="Dish"/> with the same Ingredients should be handled as identical.
    /// </summary>
    public override int GetHashCode()
        => (string.Concat(Ingredients.OrderBy(i => i.Name).Select(i => i.Name)) + DishType.ToString())
        .GetHashCode();
}