using MixMeal.Core.Models;
using MixMeal.Modules.Recommendations.Abstractions;

namespace MixMeal.Modules.Recommendations;

public class FakeRecommendationEngine : IRecommendationEngine
{
    public IEnumerable<Menu> RecommendMenus(NutritionalValues expectedNutritionalValues, IEnumerable<DishType> dishTypesToExclude)
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
                }
            },
            Name = "Your Favorite"
        };
    }
}
