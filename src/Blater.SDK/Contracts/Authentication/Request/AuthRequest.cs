namespace Blater.SDK.Contracts.Authentication.Request;

public class AuthRequest
{
    public required string Email { get; set; }

    public required string Password { get; set; }
}