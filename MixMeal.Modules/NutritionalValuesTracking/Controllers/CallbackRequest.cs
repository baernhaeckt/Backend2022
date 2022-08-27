namespace MixMeal.Modules.Recommendations.Controllers;

public class CallbackRequest
{
    public Guid Token { get; set; }

    public Guid UserId { get; set; }

    public double Calories { get; init; }

    public double Proteins { get; init; }

    public double Carbohydrates { get; init; }

    public double Fat { get; init; }
}