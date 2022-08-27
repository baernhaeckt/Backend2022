using MixMeal.Core.Models;

namespace MixMeal.Seeder.Seeds;

public class MenuSeed : SeedBase
{
    private static List<Menu> _seed = new List<Menu>();

    static MenuSeed()
    {
        _seed.Add(new Menu
        {
            Name = "Example",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Semi Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            Name = "Quinoa",
                            Tags = new List<IngredientTag>
                            {
                                IngredientTag.Create(IngredientTag.Grains)
                            },
                            Calories = 143,
                            Proteins = 14.8,
                            Carbohydrates = 64.3,
                            Fat = 6.1,
                            Icon = "quinoa",
                            ValidDishTypes = new List<DishType> { DishType.Bowl }
                        }
                    }
                }
            }
        });
    }

    private MenuSeed()
    {

    }

    public static readonly MenuSeed Instance = new MenuSeed();

    public override async Task Seed()
    {
        foreach (var menu in _seed)
        {
            Console.WriteLine($"creating new menu: {menu.Id}");
            var result = await client.PostAsync("api/menus", AsHttpJsonContent(menu));
            Console.WriteLine($"Result: {result}");
        }
    }
}
