namespace Blater.SDK.Contracts.Common.Request;

public class ResetPasswordRequest
{
    public required string NewPassword { get; set; }
    public required string OldPassword { get; set; }
}