using Microsoft.AspNetCore.Mvc;
using MixMeal.Core.Models;
using MixMeal.Modules.Menus;

namespace MixMeal.Modules.Orders;

[ApiController]
[Route("api/orders")]
public class OrdersController
{
    private readonly MenuRepository _repository;

    public OrdersController(MenuRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public Task<Menu> Submit([FromBody] Menu menu)
        => _repository.CreateOrUpdate(menu);
}
