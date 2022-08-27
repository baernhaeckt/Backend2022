using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MixMeal.Modules.Recommendations.Controllers;

[ApiController]
[Route("api/tracking")]
public class TrackingController : ControllerBase
{
    public ActionResult AddFromImage()
    {
        return NoContent();
    }

    [HttpPost]
    [AllowAnonymous] // This action is secured by a one time usage token
    public ActionResult ImageRecognitonCallback([FromBody] CallbackRequest request)
    {
        return NoContent();
    }
}
