using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MixMeal.Core.Extensions;
using MixMeal.Core.Models;
using MixMeal.Core.Repositories;
using System.Net.Http.Json;

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
    public async Task<ActionResult> AddFromImageAsync(IFormFile file)
    {
        await ForwardImageForProcessing(file);
        return NoContent();
    }

    private async Task ForwardImageForProcessing(IFormFile file)
    {
        // We know, we shouldn't do this because it opens new TCP ports for every request.
        // Will be changed to a typed client with factory later.
        var client = new HttpClient
        {
            BaseAddress = new("https://mixmeal-estimator.azurewebsites.net/api/v1/estimation") // This needs to go to config.
        };

        var payload = new
        {
            Token = Guid.NewGuid(), // Will be persisted in the future as safety mechanism
            CallbackUrl = "https://mixmeal-backend.azurewebsites.net/api/tracking/callback", // This needs to go to config.
            UserId = HttpContext.User.Id()
        };

        using var request = new HttpRequestMessage(HttpMethod.Post, "file");
        using var content = new MultipartFormDataContent
        {
            { new StreamContent(file.OpenReadStream()), file.Name, file.FileName },
            { JsonContent.Create(payload), "metadata" },
        };

        request.Content = content;
        await client.SendAsync(request);
    }

    [HttpPost("callback")]
    [AllowAnonymous] // This action is secured by a one time usage token
    public async Task<ActionResult> ImageRecognitonCallbackAsync([FromBody] CallbackRequest request)
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
