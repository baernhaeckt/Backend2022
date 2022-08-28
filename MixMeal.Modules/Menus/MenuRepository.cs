using Microsoft.EntityFrameworkCore;
using MixMeal.Core.Models;
using MixMeal.Modules.Ingredients;
using MixMeal.Persistence.PostgreSQL;

namespace MixMeal.Modules.Menus;

public class MenuRepository
{
    private readonly MixMealDbContext _dbContext;
    private readonly IngredientsRepository _ingredientsRepository;

    public MenuRepository(MixMealDbContext dbContext, IngredientsRepository ingredientsRepository)
    {
        _dbContext = dbContext;
        _ingredientsRepository = ingredientsRepository;
    }

    public async Task<Menu> CreateOrUpdate(Menu menu)
    {
        if (_dbContext.Set<Menu>().Any(m => m.Id == menu.Id))
        {
            return menu;
        }

        menu.Dishes = menu.Dishes.Select(d => GetOrCreate(d).Result).ToList();

        menu.Calories = menu.Dishes.Sum(i => i.Calories);
        menu.Proteins = menu.Dishes.Sum(i => i.Proteins);
        menu.Carbohydrates = menu.Dishes.Sum(i => i.Carbohydrates);
        menu.Fat = menu.Dishes.Sum(i => i.Fat);

        var result = _dbContext.Set<Menu>().Add(menu);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    private async Task<Dish> GetOrCreate(Dish dish)
    {
        Dish? entity = _dbContext.Set<Dish>()
            .Include(d => d.Ingredients)
            .FirstOrDefault(d => d.Id == dish.Id);
        if (entity != null)
        {
            return entity;
        }

        dish.Ingredients = dish
            .Ingredients
            .Distinct()
            .Select(i => _ingredientsRepository.GetOrCreate(i).Result)
            .ToList();

        dish.Calories = dish.Ingredients.Sum(i => i.Calories);
        dish.Proteins = dish.Ingredients.Sum(i => i.Proteins);
        dish.Carbohydrates = dish.Ingredients.Sum(i => i.Carbohydrates);
        dish.Fat = dish.Ingredients.Sum(i => i.Fat);

        var result = _dbContext.Dishes.Add(dish);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }
}
