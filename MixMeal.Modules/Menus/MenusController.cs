using Microsoft.AspNetCore.Mvc;
using MixMeal.Core.Models;

namespace MixMeal.Modules.Menus;

[ApiController]
[Route("api/menus")]
public class MenusController
{
    private readonly MenuRepository _menuRepository;

    public MenusController(MenuRepository menuRepository)
    {
        this._menuRepository = menuRepository;
    }

    /// <summary>
    ///     (ADMIN) Creates a new Menu Template to be suggested to
    ///     customers.
    /// </summary>
    [HttpPost]
    public Task<Menu> PostMenu([FromBody] Menu menu)
        => _menuRepository.CreateOrUpdate(menu);
}
