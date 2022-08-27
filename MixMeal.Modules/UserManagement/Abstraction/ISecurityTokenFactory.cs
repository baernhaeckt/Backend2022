namespace MixMeal.Modules.UserManagement.Abstraction;

public interface ISecurityTokenFactory
{
    string Create(Guid id, string subject, IEnumerable<string> roles);
}
