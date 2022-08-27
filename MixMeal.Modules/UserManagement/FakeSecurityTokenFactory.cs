using MixMeal.Modules.UserManagement.Abstraction;

namespace MixMeal.Modules.UserManagement;

public class FakeSecurityTokenFactory : ISecurityTokenFactory
{
    public string Create(int id, string subject, IEnumerable<string> roles) => "bullshit";
}
