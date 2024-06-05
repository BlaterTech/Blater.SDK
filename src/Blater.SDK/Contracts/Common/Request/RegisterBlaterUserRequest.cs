namespace Blater.SDK.Contracts.Common.Request;

public abstract class RegisterBlaterUserRequest
{
    public required BlaterId Id { get; set; }
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
}