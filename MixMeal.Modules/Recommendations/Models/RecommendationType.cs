namespace MixMeal.Modules.Recommendations.Models;

public enum RecommendationType
{
    /// <summary>
    ///     Random Recommendation to fill empty slots.
    /// </summary>
    Random,

    /// <summary>
    ///     Recommendation specially selected for the current customer
    ///     based on the profile.
    /// </summary>
    Selected,

    /// <summary>
    ///     Recommendation based on currently trending dishes.
    /// </summary>
    Trending,

    /// <summary>
    ///     Recommendation for the current customer, but slightly 
    ///     tweaked to be different.
    /// </summary>
    SelectedDifferent
}