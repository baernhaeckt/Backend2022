namespace MixMeal.Core.Models;

public class IntakeTrackingRecord
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public DateTime Timestamp { get; set; }

    public User User { get; set; }

    public double Calories { get; set; }

    public double Proteins { get; set; }

    public double Carbohydrates { get; set; }

    public double Fat { get; set; }
}
