using Microsoft.AspNetCore.Mvc;
using MixMeal.Core.Models;

namespace MixMeal.Modules.Orders;

[ApiController]
[Route("api/orders")]
public class OrdersController
{
    [HttpPost]
    public Task<Menu> Submit([FromBody] Menu menu)
    {
        return Task.FromResult<Menu>(menu);
    }
}
