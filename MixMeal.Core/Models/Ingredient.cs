using System.Collections;
using System.Formats.Asn1;

namespace MixMeal.Core.Models;

public class Ingredient
{
    public string Name { get; init; }

    public string Icon { get; init; }

    public double Calories { get; init; }

    public double Proteins { get; init; }

    public double Carbohydrates { get; init; }

    public double Fat { get; init; }

    /// <summary>
    ///     Provides a list of <see cref="Allergy"/> which could be triggered by
    ///     this <see cref="Ingredient"/>.
    /// </summary>
    public List<Allergy> Allergies { get; init; } = new List<Allergy>();

    /// <summary>
    ///     List of Tags to describe and group <see cref="Ingredient"/>.
    /// </summary>
    public List<IngredientTag> Tags { get; init; } = new List<IngredientTag>();

    public bool Premium { get; set; } = false;

    /// <summary>
    ///     Defines for which <see cref="DishType"/> this <see cref="Ingredient"/> can be used for to create a
    ///     <see cref="Dish"/>.
    /// </summary>
    public IReadOnlyCollection<DishType> ValidDishTypes { get; init; }
}