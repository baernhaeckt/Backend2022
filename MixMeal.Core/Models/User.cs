namespace MixMeal.Core.Models;

public class User
{
    public Guid Id { get; set; }

    public string DisplayName => Firstname + " " + Lastname;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public List<string> Roles { get; set; } = Enumerable.Empty<string>().ToList();

    public string Firstname { get; set; } = string.Empty;

    public string Lastname { get; set; } = string.Empty;

    /// <summary>
    /// In cm.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// In KG.
    /// </summary>
    public int Weight { get; set; }

    /// <summary>
    /// In years.
    /// </summary>
    public int Age { get; set; }

    public Sex Sex { get; set; }

    public ActivityFactorPerWeek ActivityFactor { get; set; }

    /// <summary>
    /// BMR (kcal / day) = 10 × weight (kg) + 6.25 × height (cm) – 5 × age (y) + s (kcal / day),
    /// </summary>
    public double BasalMetabolicRate => (10 * Weight + 6.25 * Height - 5 * Age + SexSpecficValue);

    private int SexSpecficValue => Sex == Sex.Male ? 5 : -161;

    /// <summary>
    ///  https://www.omnicalculator.com/health/dri#how-to-calculate-dri
    /// </summary>
    public NutritionalValues DailyDemand => new()
    {
        Calories = BasalMetabolicRate,
        Proteins = (BasalMetabolicRate * 0.2) / 4,
        Fat = (BasalMetabolicRate * 0.27) / 9,
        Carbohydrates = (BasalMetabolicRate * 0.27) / 4
    };

    public List<IntakeTrackingRecord> IntakeTrackingRecords { get; set; } = Enumerable.Empty<IntakeTrackingRecord>().ToList();

    public NutritionalValues DailyIntake => new()
    {
        Calories = IntakeTrackingRecords.Where(i => i.Timestamp.Date == DateTime.UtcNow.Date).Sum(i => i.Calories),
        Proteins = IntakeTrackingRecords.Where(i => i.Timestamp.Date == DateTime.UtcNow.Date).Sum(i => i.Proteins),
        Carbohydrates = IntakeTrackingRecords.Where(i => i.Timestamp.Date == DateTime.UtcNow.Date).Sum(i => i.Carbohydrates),
        Fat = IntakeTrackingRecords.Where(i => i.Timestamp.Date == DateTime.UtcNow.Date).Sum(i => i.Fat),
    };
}