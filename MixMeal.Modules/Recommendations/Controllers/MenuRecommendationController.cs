using Microsoft.AspNetCore.Mvc;
using MixMeal.Core.Models;
using MixMeal.Modules.Recommendations.Models;

namespace MixMeal.Modules.Recommendations.Controllers;

[ApiController]
[Route("api/recommend/menu")]
public class MenuRecommendationController
{
    [HttpPost]
    public async IAsyncEnumerable<Menu> Recommend([FromBody] RecommendMenuRequest request)
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
