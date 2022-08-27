using System.ComponentModel.DataAnnotations;

namespace MixMeal.Modules.UserManagement.Controllers;

public class RegisterUserRequest
{
    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
}
