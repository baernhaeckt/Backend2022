namespace MixMeal.Core.Models;

public class User
{
    public int Id { get; set; }

    public string DisplayName => Firstname + " " + Lastname;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public List<string> Roles { get; set; } = Enumerable.Empty<string>().ToList();

    public string Firstname { get; set; }

    public string Lastname { get; set; }
}