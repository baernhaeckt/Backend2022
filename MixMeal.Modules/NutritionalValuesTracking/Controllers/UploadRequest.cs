using Microsoft.AspNetCore.Http;

namespace MixMeal.Modules.NutritionalValuesTracking.Controllers;

public class UploadRequest
{
    public IFormFile? File { get; set; }
}
