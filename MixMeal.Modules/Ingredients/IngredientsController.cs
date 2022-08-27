using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MixMeal.Core.Models;
using MixMeal.Core.Repositories;
using MixMeal.Persistence.PostgreSQL;
using System.Reflection.Metadata.Ecma335;

namespace MixMeal.Modules.Ingredients;

[ApiController]
[Route("api/ingredients")]
public class IngredientsController
{
    private readonly MixMealDbContext dbContext;

    public IngredientsController(MixMealDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpPost]
    public async Task<Ingredient> PostIngredient(Ingredient ingredient)
    {
        ingredient.Tags = ingredient.Tags.Select(GetOrCreate).ToList();
        ingredient.Allergies = ingredient.Allergies.Select(GetOrCreate).ToList();

        var result = dbContext.Add(ingredient);
        await dbContext.SaveChangesAsync();
        return result.Entity;
    }

    private IngredientTag GetOrCreate(IngredientTag tag)
        => dbContext.Set<IngredientTag>().FirstOrDefault(e => e.Name == tag.Name) 
            ?? dbContext.Set<IngredientTag>().Add(tag).Entity;

    private Allergy GetOrCreate(Allergy allergy)
        => dbContext.Set<Allergy>().FirstOrDefault(e => e.Name == allergy.Name)
            ?? dbContext.Set<Allergy>().Add(allergy).Entity;

    [HttpGet]
    public IEnumerable<Ingredient> GetIngredients()
        => dbContext.Set<Ingredient>().Include(i => i.Allergies).Include(i => i.Tags);

    [HttpGet("forDish")]
    public IEnumerable<Ingredient> GetIngredients(DishType dish)
        => GetIngredients().Where(ingredient => ingredient.ValidDishTypes.Contains(dish));
}