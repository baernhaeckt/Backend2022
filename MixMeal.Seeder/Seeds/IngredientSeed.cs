using MixMeal.Core.Models;
using MixMeal.Seeder.Seeds;

namespace MixMeal.Modules.Ingredients;

public class IngredientSeed : SeedBase
{
    private static List<Ingredient> _seed = new List<Ingredient>();

    static IngredientSeed()
    {
        _seed.Add(
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
            });

        _seed.Add(
            new Ingredient()
            {
                Name = "Reis",
                Tags = new List<IngredientTag>
                {
                    IngredientTag.Create(IngredientTag.Grains)
                },
                Calories = 347,
                Proteins = 2.6,
                Carbohydrates = 23,
                Fat = 0.9,
                    Icon = "reis",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
            });

        _seed.Add(
            new Ingredient()
            {
                Name = "Kichererbsen",
                Tags = new List<IngredientTag>
                {
                    IngredientTag.Create(IngredientTag.Grains)
                },
                Calories = 120,
                Proteins = 7,
                Carbohydrates = 19,
                Fat = 2.4,
                    Icon = "kichererbsen",
                ValidDishTypes = new List<DishType> { DishType.Bowl }
            });

        _seed.Add(
            new Ingredient()
            {
                Name = "Apfel",
                Tags = new List<IngredientTag>
                {
                    IngredientTag.Create(IngredientTag.Fruits)
                },
                Calories = 52,
                Proteins = 0.3,
                Carbohydrates = 14,
                Fat = 0.2,
                    Icon = "apfel",
                    ValidDishTypes = new List<DishType> { DishType.Bowl, DishType.Smoothies }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Orangen",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Fruits)
                    },
                    Calories = 47,
                    Proteins = 0.9,
                    Carbohydrates = 12,
                    Fat = 0.1,
                    Icon = "orangen",
                    ValidDishTypes = new List<DishType> { DishType.Bowl, DishType.Smoothies }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Zwiebeln",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Raw)
                    },
                    Calories = 40,
                    Proteins = 1.1,
                    Carbohydrates = 9,
                    Fat = 0.1,
                    Icon = "zwiebeln",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Karotten",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Raw)
                    },
                    Calories = 41,
                    Proteins = 0.9,
                    Carbohydrates = 10,
                    Fat = 0.2,
                    Icon = "karotten",
                    ValidDishTypes = new List<DishType> { DishType.Bowl, DishType.Smoothies }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Zucchini",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Raw)
                    },
                    Calories = 17,
                    Proteins = 1.2,
                    Carbohydrates = 3.1,
                    Fat = 0.3,
                    Icon = "zucchini",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Gurken",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Raw)
                    },
                    Calories = 12,
                    Proteins = 0.7,
                    Carbohydrates = 2,
                    Fat = 0.1,
                    Icon = "gurken",
                    ValidDishTypes = new List<DishType> { DishType.Bowl, DishType.Smoothies }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Tomaten",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Raw)
                    },
                    Calories = 21,
                    Proteins = 0.7,
                    Carbohydrates = 3.5,
                    Fat = 0.3,
                    Icon = "tomaten",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Oliven",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Raw)
                    },
                    Calories = 115,
                    Proteins = 0.8,
                    Carbohydrates = 6,
                    Fat = 11,
                    Icon = "oliven",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Randen",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Steamed)
                    },
                    Calories = 48,
                    Proteins = 2,
                    Carbohydrates = 8.4,
                    Fat = 0.1,
                    Icon = "randen",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Blumenkohl",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Steamed)
                    },
                    Calories = 85,
                    Proteins = 8,
                    Carbohydrates = 8,
                    Fat = 2,
                    Icon = "blumenkohl",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Brokkoli",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Steamed)
                    },
                    Calories = 30,
                    Proteins = 4,
                    Carbohydrates = 2.8,
                    Fat = 0.2,
                    Icon = "brokkoli",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Erbsen",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Steamed)
                    },
                    Calories = 104,
                    Proteins = 6.9,
                    Carbohydrates = 13.8,
                    Fat = 0.8,
                    Icon = "erbsen",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Kartoffeln",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Steamed)
                    },
                    Calories = 77,
                    Proteins = 2,
                    Carbohydrates = 15.9,
                    Fat = 0.1,
                    Icon = "kartoffeln",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Kartoffeln",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Steamed)
                    },
                    Calories = 77,
                    Proteins = 2,
                    Carbohydrates = 15.9,
                    Fat = 0.1,
                    Icon = "kartoffeln",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Sonnenblumenkerne / Kürbiskerne",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.SeedsAndNuts)
                    },
                    Calories = 500,
                    Proteins = 19,
                    Carbohydrates = 15.9,
                    Fat = 30,
                    Icon = "sonnenblumenkernekürbiskerne",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Baumnüsse",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.SeedsAndNuts)
                    },
                    Calories = 654,
                    Proteins = 15,
                    Carbohydrates = 14,
                    Fat = 65,
                    Icon = "baumnuesse",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Mandeln",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.SeedsAndNuts)
                    },
                    Calories = 576,
                    Proteins = 24,
                    Carbohydrates = 5.7,
                    Fat = 53,
                    Icon = "mandeln",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "grilled champions",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.ExtraSideDishes)
                    },
                    Calories = 39,
                    Proteins = 6.5,
                    Carbohydrates = 0.5,
                    Fat = 0.39,
                    Icon = "grilledchampions",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "grilled pepperoni",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.ExtraSideDishes)
                    },
                    Calories = 29,
                    Proteins = 0.5,
                    Carbohydrates = 2,
                    Fat = 0.9,
                    Icon = "grilledpepperoni",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Avocado",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.ExtraSideDishes)
                    },
                    Calories = 160,
                    Proteins = 1.5,
                    Carbohydrates = 2,
                    Fat = 13,
                    Icon = "avocado",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "planted chicken",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.ExtraSideDishes)
                    },
                    Calories = 151,
                    Proteins = 24,
                    Carbohydrates = 2.1,
                    Fat = 2.9,
                    Icon = "plantedchicken",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Karottenlachs",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.ExtraSideDishes)
                    },
                    Calories = 75,
                    Proteins = 0.9,
                    Carbohydrates = 6.7,
                    Fat = 4.2,
                    Icon = "karottenlachs",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Fetakäse",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.ExtraSideDishes)
                    },
                    Calories = 264,
                    Proteins = 14,
                    Carbohydrates = 4.1,
                    Fat = 21,
                    Icon = "fetakaese",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "grüner Salat",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.GreenSalat)
                    },
                    Calories = 40.8,
                    Proteins = 0,
                    Carbohydrates = 4.5,
                    Fat = 2.9,
                    Icon = "gruenersalat",
                    ValidDishTypes = new List<DishType> { DishType.Bowl }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Cubes",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Cubes)
                    },
                    Calories = 182.4,
                    Proteins = 2.5,
                    Carbohydrates = 24,
                    Fat = 5,
                    Icon = "cubes",
                    ValidDishTypes = new List<DishType> { DishType.PotatoCubes }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Bananeneis",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.IceCream)
                    },
                    Calories = 99,
                    Proteins = 1.2,
                    Carbohydrates = 22.2,
                    Fat = 0.2,
                    Icon = "bananeneis",
                    ValidDishTypes = new List<DishType> { DishType.Ice }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Beerenmischung",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.IceCream)
                    },
                    Calories = 71,
                    Proteins = 1.05,
                    Carbohydrates = 14.75,
                    Fat = 0,
                    Icon = "beerenmischung",
                    ValidDishTypes = new List<DishType> { DishType.Ice }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Haselnüsse",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.IceCream)
                    },
                    Calories = 231,
                    Proteins = 4.65,
                    Carbohydrates = 20.9,
                    Fat = 61,
                    Icon = "haselnüsse",
                    ValidDishTypes = new List<DishType> { DishType.Ice }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Erbsenprotein",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.IceCream)
                    },
                    Calories = 102.5,
                    Proteins = 20,
                    Carbohydrates = 0.25,
                    Fat = 2.5,
                    Icon = "erbsenprotein",
                    ValidDishTypes = new List<DishType> { DishType.Ice }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Ingwer",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Raw)
                    },
                    Calories = 50,
                    Proteins = 1.2,
                    Carbohydrates = 9,
                    Fat = 1,
                    Icon = "ingwer",
                    ValidDishTypes = new List<DishType> { DishType.Smoothies }
                });

            _seed.Add(
                new Ingredient()
                {
                    Name = "Zitronen",
                    Tags = new List<IngredientTag>
                    {
                        IngredientTag.Create(IngredientTag.Raw)
                    },
                    Calories = 39,
                    Proteins = 0.7,
                    Carbohydrates = 3.2,
                    Fat = 0.6,
                    Icon = "zitronen",
                    ValidDishTypes = new List<DishType> { DishType.Smoothies }
            });
    }

    private IngredientSeed()
    {

    }

    public static readonly IngredientSeed Instance = new IngredientSeed();

    public override Task Seed()
        => Post("api/ingredients", _seed);
}
