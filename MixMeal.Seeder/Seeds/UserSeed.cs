using MixMeal.Core.Models;
using MixMeal.Core;

namespace MixMeal.Seeder.Seeds;

class UserSeed : SeedBase
{
	private static List<User> _seed = new List<User>();

	static UserSeed()
	{
        _seed.Add(
            new UserSeed
            {
                Email = "marc@xunganstattpfund.ch",
                Firstname = "Marc",
                Lastname = "Xung",
                Height = 1.70,
                Weight = 80,
                Age = 35,
                Sex = Sex.Male
            }
        );

        _seed.Add(
            new UserSeed
            {
                Email = "fabienne@xunganstattpfund.ch",
                Firstname = "Fabienne",
                Lastname = "Meier",
                Height = 1.50,
                Weight = 60,
                Age = 30,
                Sex = Sex.Female
            }
        );

        _seed.Add(
            new UserSeed
            {
                Email = "chrigu@xunganstattpfund.ch",
                Firstname = "Chrigu",
                Lastname = "Keller",
                Height = 1.75,
                Weight = 80,
                Age = 36,
                Sex = Sex.Male
            }
        );

        _seed.Add(
            new UserSeed
            {
                Email = "hans@xunganstattpfund.ch",
                Firstname = "hans",
                Lastname = "Müller",
                Height = 1.95,
                Weight = 100,
                Age = 49,
                Sex = Sex.Male
            }
        );
    }

    private UserSeed()
    {

    }

    public static readonly UserSeed Instance = new UserSeed();

    public override async Task Seed()
    {
        foreach (var user in _seed)
        {
            await client.PostAsync("api/users/register", AsHttpJsonContent(user));
        }
    }
}
