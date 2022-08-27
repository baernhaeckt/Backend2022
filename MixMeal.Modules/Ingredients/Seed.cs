﻿using MixMeal.Core.Models;
using MixMeal.Core.Repositories;

namespace MixMeal.Modules.Ingredients
{
    public static class Seed
    {
        private static List<Ingredient> _seed = new List<Ingredient>();

        static Seed()
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
                    Icon = "🍚",
                    ValidDishTypes = new List<DishType> { DishType.Bowl, DishType.Ice }
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
                    Icon = "chickpea",
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
                    Icon = "🍎",
                    ValidDishTypes = new List<DishType> { DishType.Bowl, DishType.Ice, DishType.Smoothies }
                });
        }

        public static Task Insert(IRepository<Ingredient> repository)
            => Task.WhenAll(_seed.Select(r => repository.Create(r)));
    }
}