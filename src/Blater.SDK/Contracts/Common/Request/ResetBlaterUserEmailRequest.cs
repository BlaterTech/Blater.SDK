namespace Blater.SDK.Contracts.Common.Request;

public class ResetBlaterUserEmailRequest
{
    public required string NewEmail { get; set; }
    public required string Password { get; set; }
}