namespace Blater.SDK.Contracts.Common.Request;

public abstract class ResetBlaterUserEmailRequest
{
    public required string NewEmail { get; set; }
    public required string Password { get; set; }
}