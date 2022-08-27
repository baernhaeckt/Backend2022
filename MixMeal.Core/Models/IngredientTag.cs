namespace MixMeal.Core.Models;

public class IngredientTag
{
    public string Name { get; set; }

    public static IngredientTag Create(string name)
        => new IngredientTag { Name = name };


    public const string Grains = "Getreide und Hülsenfrüchte";
    public const string Fruits = "Früchte";
    public const string Raw = "Roh";
    public const string Steamed = "gedämpft";
    public const string SeedsAndNuts = "Kerne und Nüsse";
    public const string ExtraSideDishes = "extra Beilagen";
    public const string GreenSalat = "grüner Salat";
    public const string Cubes = "Cubes";
}
