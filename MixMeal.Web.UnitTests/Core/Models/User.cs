using FluentAssertions;
using MixMeal.Core.Models;
using Xunit;

namespace MixMeal.Web.UnitTests.Core.Models;

public class UserFixture
{
    /// <summary>
    /// 10 × 68.04 + 6.25 × 162.56 – 5 × 60 + 5 = 680.4 + 1016 – 300 + 5 = 1401.4 (kcal / day)
    /// </summary>
    [Fact]
    public void BasalMetabolicRate_ShouldReturnCorrectCalculation_WhenMale()
    {
        // Arrange
        User user = new();
        user.Age = 60;
        user.Height = 162;
        user.Weight = 68;
        user.Sex = MixMeal.Core.Sex.Male;

        // Act
        double result = user.BasalMetabolicRate;

        // Assert
        result.Should().Be(1397.5);
    }

    /// <summary>
    /// 10 × 59.87 + 6.25 × 172.72 – 5 × 25 - 161 = 598.7 + 1079.5 – 125 – 161 = 1392.2 (kcal / day)
    /// </summary>
    [Fact]
    public void BasalMetabolicRate_ShouldReturnCorrectCalculation_WhenFemale()
    {
        // Arrange
        User user = new();
        user.Age = 25;
        user.Height = 172;
        user.Weight = 60;
        user.Sex = MixMeal.Core.Sex.Female;

        // Act
        double result = user.BasalMetabolicRate;

        // Assert
        result.Should().Be(1389);
    }
}
