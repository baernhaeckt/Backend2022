namespace MixMeal.Core.Models;

public class IngredientTag
{
    public string Name { get; set; }

    public static IngredientTag Create(string name)
        => new IngredientTag { Name = name };


    public const string Grains = "Getreide und Hülsenfrüchte";
    public const string Fruits = "Früchte";
}
