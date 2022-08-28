using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

    [HttpPost("callback")]
    [AllowAnonymous] // This action is secured by a one time usage token
    public async Task<ActionResult> ImageRecognitonWebhook([FromBody] CallbackRequest request)
    {
        await _repository.Create(new IntakeTrackingRecord
        {
            Timestamp = DateTime.UtcNow,
            Calories = request.estimations.Sum(e => e.estimated_calories),
            Carbohydrates = request.estimations.Sum(e => e.estimated_carbohydrates),
            Proteins = request.estimations.Sum(e => e.estimated_protein),
            Fat = request.estimations.Sum(e => e.estimated_fat),
            UserId = request.user_id
        });
        return NoContent();
    }
}
