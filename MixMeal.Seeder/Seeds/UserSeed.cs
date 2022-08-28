using MixMeal.Core.Models;
using MixMeal.Core;

namespace MixMeal.Seeder.Seeds;

class UserSeed : SeedBase
{
	private static readonly List<User> _seed = new();

	static UserSeed()
	{
        _seed.Add(
            new User
            {
                Email = "marc@xunganstattpfung.ch",
                Firstname = "Marc",
                Lastname = "Xung",
                Height = 170,
                Weight = 80,
                Age = 35,
                Sex = Sex.Male,
                ActivityFactor = ActivityFactorPerWeek.SixToSevenTimes
            }
        );

        _seed.Add(
            new User
            {
                Email = "fabienne@xunganstattpfung.ch",
                Firstname = "Fabienne",
                Lastname = "Meier",
                Height = 150,
                Weight = 60,
                Age = 30,
                Sex = Sex.Female,
                ActivityFactor = ActivityFactorPerWeek.ThreeToFiveTimes
            }
        );

        _seed.Add(
            new User
            {
                Email = "chrigu@xunganstattpfung.ch",
                Firstname = "Chrigu",
                Lastname = "Keller",
                Height = 175,
                Weight = 80,
                Age = 36,
                Sex = Sex.Male,
                ActivityFactor = ActivityFactorPerWeek.TwoToThreeTimes
            }
        );

        _seed.Add(
            new User
            {
                Email = "hans@xunganstattpfung.ch",
                Firstname = "hans",
                Lastname = "Müller",
                Height = 195,
                Weight = 100,
                Age = 49,
                Sex = Sex.Male,
                ActivityFactor = ActivityFactorPerWeek.LittleOrNo
            }
        );
    }

    private UserSeed()
    {

    }

    public static readonly UserSeed Instance = new();

    public override Task Seed()
        => Post("api/users/register", _seed);
}
