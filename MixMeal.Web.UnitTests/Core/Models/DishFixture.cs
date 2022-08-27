using FluentAssertions;
using MixMeal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MixMeal.Web.UnitTests.Core.Models;

public class DishFixture
{
    [Fact]
    public void GetHashcode_ShouldReturnSameCodeForSameObject()
    {
        // Arrange
        Dish dish = new Dish()
        {
            Name = "Test0001",
            DishType = DishType.Bowl,
            Ingredients = new List<Ingredient>()
            {
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "B" },
            }
        };

        // Act && Assert
        dish.GetHashCode().Should().Be(dish.GetHashCode());
    }

    [Fact]
    public void GetHashcode_ShouldReturnSameCodeForDifferentObjectWithDifferentName()
    {
        // Arrange
        Dish dish = new Dish()
        {
            Name = "Test0001",
            DishType = DishType.Bowl,
            Ingredients = new List<Ingredient>()
            {
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "B" },
            }
        };
        Dish dish2 = new Dish()
        {
            Name = "Test0002",
            DishType = DishType.Bowl,
            Ingredients = new List<Ingredient>()
            {
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "B" },
            }
        };

        // Act && Assert
        dish.GetHashCode().Should().Be(dish2.GetHashCode());
    }

    [Fact]
    public void GetHashcode_ShouldReturnDifferentCodeForDifferentObjectWithDifferentType()
    {
        // Arrange
        Dish dish = new Dish()
        {
            Name = "Test0001",
            DishType = DishType.Bowl,
            Ingredients = new List<Ingredient>()
            {
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "B" },
            }
        };
        Dish dish2 = new Dish()
        {
            Name = "Test0002",
            DishType = DishType.Ice,
            Ingredients = new List<Ingredient>()
            {
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "B" },
            }
        };

        // Act && Assert
        dish.GetHashCode().Should().NotBe(dish2.GetHashCode());
    }

    [Fact]
    public void GetHashcode_ShouldReturnSameCodeForDifferentObjectWithDifferentOrder()
    {
        // Arrange
        Dish dish = new Dish()
        {
            Name = "Test0001",
            DishType = DishType.Bowl,
            Ingredients = new List<Ingredient>()
            {
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "B" },
            }
        };
        Dish dish2 = new Dish()
        {
            Name = "Test0001",
            DishType = DishType.Bowl,
            Ingredients = new List<Ingredient>()
            {
                new Ingredient() { Name = "B" },
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "A" },
            }
        };

        // Act && Assert
        dish.GetHashCode().Should().Be(dish2.GetHashCode());
    }


    [Fact]
    public void GetHashcode_ShouldReturnDifferentCodeForDifferentIngredients()
    {
        // Arrange
        Dish dish = new Dish()
        {
            Name = "Test0001",
            DishType = DishType.Bowl,
            Ingredients = new List<Ingredient>()
            {
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "A" },
                new Ingredient() { Name = "B" },
            }
        };
        Dish dish2 = new Dish()
        {
            Name = "Test0001",
            DishType = DishType.Bowl,
            Ingredients = new List<Ingredient>()
            {
                new Ingredient() { Name = "B" },
                new Ingredient() { Name = "C" },
            }
        };

        // Act && Assert
        dish.GetHashCode().Should().NotBe(dish2.GetHashCode());
    }
}
