namespace Blater.SDK.Contracts.Common.Request;

public class ResetBlaterUserEmailRequest
{
    public required string NewEmail { get; set; }
    public required string PasswordHash { get; set; }
}