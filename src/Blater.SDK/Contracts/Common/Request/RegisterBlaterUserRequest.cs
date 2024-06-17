namespace Blater.SDK.Contracts.Common.Request;

public class RegisterBlaterUserRequest
{
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
}