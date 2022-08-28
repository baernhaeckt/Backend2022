using System.Text.Json.Serialization;

namespace MixMeal.Core.Models;

public class Ingredient : NutritionalValues
{
    public string Name { get; init; }

    public string Icon { get; init; }

    /// <summary>
    ///     Provides a list of <see cref="Allergy"/> which could be triggered by
    ///     this <see cref="Ingredient"/>.
    /// </summary>
    public List<Allergy> Allergies { get; set; } = new List<Allergy>();

    /// <summary>
    ///     List of Tags to describe and group <see cref="Ingredient"/>.
    /// </summary>
    public List<IngredientTag> Tags { get; set; } = new List<IngredientTag>();


    [JsonIgnore]
    public IReadOnlyCollection<Dish> UsedIn { get; set; } = new List<Dish>();

    public bool Premium { get; set; } = false;

    /// <summary>
    ///     Defines for which <see cref="DishType"/> this <see cref="Ingredient"/> can be used for to create a
    ///     <see cref="Dish"/>.
    /// </summary>
    public IReadOnlyCollection<DishType> ValidDishTypes { get; init; }
}