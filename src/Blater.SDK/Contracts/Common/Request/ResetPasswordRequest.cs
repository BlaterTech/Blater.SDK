namespace Blater.SDK.Contracts.Common.Request;

public class ResetPasswordRequest
{
    public required string Email { get; set; }
    public required string NewPassword { get; set; }
    public required string OldPassword { get; set; }
}