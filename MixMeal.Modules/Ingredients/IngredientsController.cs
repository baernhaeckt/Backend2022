using Microsoft.AspNetCore.Mvc;
using MixMeal.Core.Models;

namespace MixMeal.Modules.Ingredients;

[ApiController]
[Route("api/ingredients")]
public class IngredientsController
{
    private readonly IngredientsRepository repository;

    public IngredientsController(IngredientsRepository repository)
    {
        this.repository = repository;
    }

    [HttpPost]
    public Task<Ingredient> PostIngredient(Ingredient ingredient)
        => repository.GetOrCreate(ingredient);

    /// <summary>
    ///     Get all <see cref="Ingredient"/> present.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<Ingredient> GetIngredients()
        => repository.GetIngredients();

    /// <summary>
    ///     Get all <see cref="Ingredient"/> valid for the given <see cref="DishType"/>.
    /// </summary>
    /// <param name="dish"></param>
    /// <returns></returns>
    [HttpGet("forDish")]
    public IEnumerable<Ingredient> GetIngredients(DishType dish)
        => repository.GetIngredients(dish);
}