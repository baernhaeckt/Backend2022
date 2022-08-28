using MixMeal.Core;
using System.ComponentModel.DataAnnotations;

namespace MixMeal.Modules.UserManagement.Controllers;

public class RegisterUserRequest
{
    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Firstname { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Lastname { get; set; } = string.Empty;

    [Required]
    public int Height { get; set; }

    [Required]
    public int Weight { get; set; }

    [Required]
    public int Age { get; set; }

    [Required]
    public Sex Sex { get; set; }

    [Required]
    public ActivityFactorPerWeek ActivityFactor { get; set; }
}
