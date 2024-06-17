namespace Blater.SDK.Contracts.Common.Request;

public class ResetBlaterUserPasswordRequest
{
    public required string NewPassword { get; set; }
    public required string OldPassword { get; set; }
}