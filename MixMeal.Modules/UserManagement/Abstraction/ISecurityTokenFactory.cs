namespace MixMeal.Modules.UserManagement.Abstraction;

public interface ISecurityTokenFactory
{
    string Create(int id, string subject, IEnumerable<string> roles);
}
