using MixMeal.Modules.UserManagement.Abstraction;

namespace MixMeal.Modules.UserManagement.Security;

public class FakeSecurityTokenFactory : ISecurityTokenFactory
{
    public string Create(Guid id, string subject, IEnumerable<string> roles) => "bullshit";
}
