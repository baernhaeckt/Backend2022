﻿using Microsoft.AspNetCore.Mvc;
using MixMeal.Core.Models;
using MixMeal.Core.Repositories;

namespace MixMeal.Modules.Ingredients;

[ApiController]
[Route("api/_admin/{controller}")]
public class IngredientsController
{
    private readonly IRepository<Ingredient> repository;

    public IngredientsController(IRepository<Ingredient> repository)
    {
        this.repository = repository;
    }

    [HttpPost]
    public Task<Ingredient> PostIngredient(Ingredient ingredient)
        => repository.Create(ingredient);

    [HttpGet]
    public IAsyncEnumerable<Ingredient> GetIngredients()
        => repository.GetAll();
}