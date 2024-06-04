namespace Blater.SDK.Contracts.Authentication.Response;

public class AuthToken
{
    public BlaterId? UserId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}