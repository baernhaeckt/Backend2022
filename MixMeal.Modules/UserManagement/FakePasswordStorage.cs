using MixMeal.Modules.UserManagement.Abstraction;

namespace MixMeal.Modules.UserManagement;

public class FakePasswordStorage : IPasswordStorage
{
    public string Create(string password) => password;

    public bool Match(string password, string goodHash) => true;
}
