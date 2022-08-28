using Microsoft.EntityFrameworkCore;
using MixMeal.Core.Models;
using MixMeal.Persistence.PostgreSQL;

namespace MixMeal.Modules.Ingredients;

public class IngredientsRepository
{
    private readonly MixMealDbContext _dbContext;

    public IngredientsRepository(MixMealDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Ingredient> GetOrCreate(Ingredient ingredient)
    {
        Ingredient? entity = _dbContext.Ingredients.FirstOrDefault(i => i.Name == ingredient.Name);
        if (entity != null)
        {
            return entity;
        }

        ingredient.Tags = ingredient.Tags.Select(GetOrCreate).ToList();
        ingredient.Allergies = ingredient.Allergies.Select(GetOrCreate).ToList();

        var result = _dbContext.Add(ingredient);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    private IngredientTag GetOrCreate(IngredientTag tag)
        => _dbContext.Set<IngredientTag>().FirstOrDefault(e => e.Name == tag.Name)
            ?? _dbContext.Set<IngredientTag>().Add(tag).Entity;

    private Allergy GetOrCreate(Allergy allergy)
        => _dbContext.Set<Allergy>().FirstOrDefault(e => e.Name == allergy.Name)
            ?? _dbContext.Set<Allergy>().Add(allergy).Entity;


    /// <summary>
    ///     Get all <see cref="Ingredient"/> present.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Ingredient> GetIngredients()
        => _dbContext.Set<Ingredient>().Include(i => i.Allergies).Include(i => i.Tags);

    /// <summary>
    ///     Get all <see cref="Ingredient"/> valid for the given <see cref="DishType"/>.
    /// </summary>
    /// <param name="dish"></param>
    /// <returns></returns>
    public IEnumerable<Ingredient> GetIngredients(DishType dish)
        => GetIngredients().Where(ingredient => ingredient.ValidDishTypes.Contains(dish));
}
