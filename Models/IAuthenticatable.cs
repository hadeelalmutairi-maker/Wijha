namespace Wijha.Models;

public interface IAuthenticatable
{
    int Id { get; }

    string Email { get; }

    string GetAuthPassword();
}
