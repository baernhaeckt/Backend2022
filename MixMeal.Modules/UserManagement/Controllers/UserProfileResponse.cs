using MixMeal.Core;
using MixMeal.Core.Models;

namespace MixMeal.Modules.UserManagement.Controllers;

public class UserProfileResponse
{
    public UserProfileResponse(Guid id, string displayName, string email, Sex sex, int age, int height, ActivityFactorPerWeek activityFactor, NutritionalValues dailyDemand, List<IntakeTrackingRecord> intakeTrackingRecords)
    {
        Id = id;
        DisplayName = displayName;
        Email = email;
        Sex = sex;
        Age = age;
        Height = height;
        ActivityFactor = activityFactor;
        DailyDemand = dailyDemand;
        IntakeTrackingRecords = intakeTrackingRecords;
    }

    public Guid Id { get; }

    public string DisplayName { get; }

    public string Email { get; }

    public Sex Sex { get; }

    public int Age { get; }

    public int Height { get; }

    public ActivityFactorPerWeek ActivityFactor { get; }

    public NutritionalValues DailyDemand { get; }

    public List<IntakeTrackingRecord> IntakeTrackingRecords { get; }
}