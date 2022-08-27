using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MixMeal.Core.Extensions;
using MixMeal.Core.Models;
using MixMeal.Core.Repositories;

namespace MixMeal.Modules.Recommendations.Controllers;

[ApiController]
[Route("api/tracking")]
public class TrackingController : ControllerBase
{
    private readonly IRepository<IntakeTrackingRecord> _repository;

    public TrackingController(IRepository<IntakeTrackingRecord> repository)
    {
        _repository = repository;
    }

    [HttpPost("upload")]
    public ActionResult AddFromImage()
    {
        return NoContent();
    }

    [HttpPost("callback")]
    [AllowAnonymous] // This action is secured by a one time usage token
    public async Task<ActionResult> ImageRecognitonCallbackAsync([FromBody] CallbackRequest request)
    {
        await _repository.Create(new IntakeTrackingRecord
        {
            Timestamp = DateTime.UtcNow,
            Calories = request.Calories,
            Carbohydrates = request.Carbohydrates,
            Proteins = request.Proteins,
            Fat = request.Fat,
            UserId = request.UserId
        });
        return NoContent();
    }
}
