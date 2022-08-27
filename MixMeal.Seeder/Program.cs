﻿using Cocona;
using Microsoft.Extensions.Configuration;
using MixMeal.Modules.Ingredients;
using MixMeal.Seeder;
using MixMeal.Seeder.Seeds;

var app = CoconaApp.CreateBuilder().Build();

app.AddCommand("seed", async (Seed? seed) =>
{
    switch (seed)
    {
        case Seed.Ingredient:
            await IngredientSeed.Instance.Seed();
            break;
        case Seed.Menu:
            await MenuSeed.Instance.Seed();
            break;
        default:
            Console.WriteLine("Seeding all");
            break;
    }
});

app.Run();