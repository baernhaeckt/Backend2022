using MixMeal.Core.Models;
using MixMeal.Modules.Recommendations.Abstractions;

namespace MixMeal.Modules.Recommendations;

public class FakeRecommendationEngine : IRecommendationEngine
{
    public IEnumerable<Menu> GetData()
    {
        yield return new Menu()
        {
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "SuperBowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient() {
                            Name = "Rüebli",
                            Icon = "🥕",
                            Calories = 17,
                            Carbohydrates = 7,
                            Fat = 0,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Bowl,
                                DishType.Ice
                            }
                        },
                        new Ingredient() {
                            Name = "Rüebli",
                            Icon = "🥕",
                            Calories = 17,
                            Carbohydrates = 7,
                            Fat = 0,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Bowl,
                                DishType.Ice
                            }
                        },
                        new Ingredient() {
                            Name = "Avocado",
                            Icon = "🥑",
                            Calories = 17,
                            Carbohydrates = 7,
                            Fat = 120,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Bowl,
                                DishType.Ice
                            }
                        },
                        new Ingredient() {
                            Name = "Pilzli",
                            Icon = "🍄",
                            Calories = 30,
                            Carbohydrates = 10,
                            Fat = 10,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Bowl,
                                DishType.Ice
                            }
                        }
                    }
                },
                new Dish()
                {
                    Name = "PowerCube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient() {
                            Name = "Potato",
                            Icon = "🥔",
                            Calories = 23,
                            Carbohydrates = 3,
                            Fat = 1,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.PotatoCubes
                            }
                        }
                    }
                },
                new Dish()
                {
                    Name = "Dr Sünder",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient() {
                            Name = "Vanille",
                            Icon = "🍨",
                            Calories = 70,
                            Carbohydrates = 3,
                            Fat = 10,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Ice
                            }
                        }
                    }
                }
            },
            Name = "Your Favorite"
        };

        yield return new Menu()
        {
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "LovelyBowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient() {
                            Name = "Broccoli",
                            Icon = "🥦",
                            Calories = 17,
                            Carbohydrates = 7,
                            Fat = 0,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Bowl
                            }
                        },
                        new Ingredient() {
                            Name = "Gurken",
                            Icon = "🥒",
                            Calories = 2,
                            Carbohydrates = 2,
                            Fat = 0,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Bowl
                            }
                        },
                        new Ingredient() {
                            Name = "Avocado",
                            Icon = "🥑",
                            Calories = 17,
                            Carbohydrates = 7,
                            Fat = 120,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Bowl,
                                DishType.Ice
                            }
                        },
                        new Ingredient() {
                            Name = "Tomato",
                            Icon = "🍅",
                            Calories = 3,
                            Carbohydrates = 1,
                            Fat = 1,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Bowl
                            }
                        }
                    }
                },
                new Dish()
                {
                    Name = "PowerCube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient() {
                            Name = "Potato",
                            Icon = "🥔",
                            Calories = 23,
                            Carbohydrates = 3,
                            Fat = 1,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.PotatoCubes
                            }
                        }
                    }
                },
                new Dish()
                {
                    Name = "Dr Sünder",
                    DishType = DishType.Ice,
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient() {
                            Name = "Vanille",
                            Icon = "🍨",
                            Calories = 70,
                            Carbohydrates = 3,
                            Fat = 10,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Ice
                            }
                        }
                    }
                }
            },
            Name = "Your Favorite"
        };

        yield return new Menu()
        {
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "LovelyBowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient() {
                            Name = "Broccoli",
                            Icon = "🥦",
                            Calories = 17,
                            Carbohydrates = 7,
                            Fat = 0,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Bowl
                            }
                        },
                        new Ingredient() {
                            Name = "Gurken",
                            Icon = "🥒",
                            Calories = 2,
                            Carbohydrates = 2,
                            Fat = 0,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Bowl
                            }
                        }
                    }
                },
                new Dish()
                {
                    Name = "PowerCube",
                    DishType = DishType.PotatoCubes,
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient() {
                            Name = "Potato",
                            Icon = "🥔",
                            Calories = 23,
                            Carbohydrates = 3,
                            Fat = 1,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.PotatoCubes
                            }
                        }
                    }
                }
            },
            Name = "Your Favorite"
        };

        yield return new Menu()
        {
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "SuperBowl",
                    DishType = DishType.Bowl,
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient() {
                            Name = "Rüebli",
                            Icon = "🥕",
                            Calories = 17,
                            Carbohydrates = 7,
                            Fat = 0,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Bowl,
                                DishType.Ice
                            }
                        },
                        new Ingredient() {
                            Name = "Rüebli",
                            Icon = "🥕",
                            Calories = 17,
                            Carbohydrates = 7,
                            Fat = 0,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Bowl,
                                DishType.Ice
                            }
                        },
                        new Ingredient() {
                            Name = "Avocado",
                            Icon = "🥑",
                            Calories = 17,
                            Carbohydrates = 7,
                            Fat = 120,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Bowl,
                                DishType.Ice
                            }
                        },
                        new Ingredient() {
                            Name = "Pilzli",
                            Icon = "🍄",
                            Calories = 30,
                            Carbohydrates = 10,
                            Fat = 10,
                            ValidDishTypes = new List<DishType>
                            {
                                DishType.Bowl,
                                DishType.Ice
                            }
                        }
                    }
                }
            },
            Name = "Your Favorite"
        };
    }

    public IEnumerable<Dish> RecommendDishes(NutritionalValues expectedNutritionalValues, DishType dishType)
         => GetData().SelectMany(m => m.Dishes).Where(m => m.DishType == dishType).Take(5);

    public IEnumerable<Menu> RecommendMenus(NutritionalValues expectedNutritionalValues, IEnumerable<DishType> dishTypesToExclude)
        => GetData().Where(m => !HasDishesOfTypes(m, dishTypesToExclude)).Take(5);

    private bool HasDishesOfTypes(Menu menu, IEnumerable<DishType> dishesToCheck)
        => menu.Dishes.Select(d => d.DishType).Intersect(dishesToCheck).Any();
}
