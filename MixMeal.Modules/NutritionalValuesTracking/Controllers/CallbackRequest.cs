namespace MixMeal.Modules.Recommendations.Controllers;

public class CallbackRequest
{
    public Guid user_id { get; set; }

    public Guid token { get; set; }

    public Estimation[] estimations { get; set; }
}

public class Estimation
{
    public string class_name { get; set; }

    public float estimated_calories { get; set; }

    public float estimated_protein { get; set; }

    public float estimated_fat { get; set; }

    public float estimated_carbohydrates { get; set; }
}