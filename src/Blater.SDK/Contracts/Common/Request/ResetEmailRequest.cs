namespace Blater.SDK.Contracts.Common.Request;

public class ResetEmailRequest
{
    public required string NewEmail { get; set; }
    public required string Password { get; set; }
}