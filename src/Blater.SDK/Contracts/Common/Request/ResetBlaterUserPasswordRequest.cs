namespace Blater.SDK.Contracts.Common.Request;

public class ResetBlaterUserPasswordRequest
{
    public required string NewPasswordHash { get; set; }
    public required string OldPasswordHash { get; set; }
}