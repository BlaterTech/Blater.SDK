namespace Blater.SDK.Contracts.Authentication.Response;

public class AuthToken
{
    public Ulid? UserId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}