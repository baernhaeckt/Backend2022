namespace MixMeal.Core.Models;

public class NutritionalValues
{
    public double Calories { get; set; }

    public double Proteins { get; set; }

    public double Carbohydrates { get; set; }

    public double Fat { get; set; }

    public double Distance(NutritionalValues other)
        => Math.Abs(other.Calories - Calories) 
        + Math.Abs(other.Proteins - Proteins)
        + Math.Abs(other.Carbohydrates - Carbohydrates)
        + Math.Abs(other.Fat - Fat);

    public NutritionalValues Diff(NutritionalValues other)
    {
        return new NutritionalValues()
        {
            Calories = Calories - other.Calories,
            Proteins = Proteins - other.Proteins,
            Carbohydrates = Carbohydrates - other.Carbohydrates,
            Fat = Fat - other.Fat
        };
    }
}
