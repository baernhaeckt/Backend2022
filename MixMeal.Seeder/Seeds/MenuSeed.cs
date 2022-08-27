using MixMeal.Core.Models;

namespace MixMeal.Seeder.Seeds;

public class MenuSeed : SeedBase
{
    private static List<Menu> _seed = new List<Menu>();

    static MenuSeed()
    {
        _seed.Add(new Menu
        {
            Name = "Menu 1",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Small Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
				{
                    Name = "Small Cube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
				{
                    Name = "Small Ice Cream",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
					{
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
                        }
                    }
                }
            }
        });

        _seed.Add(new Menu
        {
            Name = "Menu 2",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Small Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Medium Cube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Ice Cream",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                }
            }
        });

        _seed.Add(new Menu
        {
            Name = "Menu 3",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Small Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Large Cube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Ice Cream",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                }
            }
        });

        _seed.Add(new Menu
        {
            Name = "Menu 4",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Medium Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
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
                        },
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
                        },
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Cube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Ice Cream",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                }
            }
        });

        _seed.Add(new Menu
        {
            Name = "Menu 5",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Medium Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
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
                        },
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
                        },
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Cube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Ice Cream",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                }
            }
        });

        _seed.Add(new Menu
        {
            Name = "Menu 6",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Large Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
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
                        },
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
                        },
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
                        },
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
                        },
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Cube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Ice Cream",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                }
            }
        });

        _seed.Add(new Menu
        {
            Name = "Menu 7",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Small Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Cube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Jucie",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                }
            }
        });

        _seed.Add(new Menu
        {
            Name = "Menu 8",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Small Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
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
                        },
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
                        },
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
                        },
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
                        },
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Cube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Jucie",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                }
            }
        });

        _seed.Add(new Menu
        {
            Name = "Menu 9",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Small Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Medium Cube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Jucie",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                }
            }
        });

        _seed.Add(new Menu
        {
            Name = "Menu 10",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Medium Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
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
                        },
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
                        },
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Cube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Jucie",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                }
            }
        });

        _seed.Add(new Menu
        {
            Name = "Menu 11",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Medium Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
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
                        },
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
                        },
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Cube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Ice Cream",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                }
            }
        });

        _seed.Add(new Menu
        {
            Name = "Menu 12",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Large Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
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
                        },
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
                        },
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
                        },
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
                        },
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Cube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Ice Cream",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                }
            }
        });

        _seed.Add(new Menu
        {
            Name = "Menu 13",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Small Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Cube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Jucie",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                }
            }
        });

        _seed.Add(new Menu
        {
            Name = "Menu 14",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Medium Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
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
                        },
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
                        },
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Cube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Jucie",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                }
            }
        });

        _seed.Add(new Menu
        {
            Name = "Menu 15",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Large Bowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
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
                        },
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
                        },
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
                        },
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
                        },
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Cube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
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
                        }
                    }
                },
                new Dish()
                {
                    Name = "Small Jucie",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
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
