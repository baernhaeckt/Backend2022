using Cocona;
using MixMeal.Modules.Ingredients;
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
        case Seed.User:
            await UserSeed.Instance.Seed();
            break;
        default:
            await IngredientSeed.Instance.Seed();
            await MenuSeed.Instance.Seed();
            await UserSeed.Instance.Seed();
            break;
    }
});

app.Run();