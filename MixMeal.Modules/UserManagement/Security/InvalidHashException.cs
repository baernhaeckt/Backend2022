namespace MixMeal.Modules.UserManagement;

public class InvalidHashException : Exception
{
    public InvalidHashException()
    {
    }

    public InvalidHashException(string message)
        : base(message)
    {
    }

    public InvalidHashException(string message, Exception inner)
        : base(message, inner)
    {
    }
}