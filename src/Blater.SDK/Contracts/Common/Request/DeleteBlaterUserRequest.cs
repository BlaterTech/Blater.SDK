namespace Blater.SDK.Contracts.Common.Request;

public class DeleteBlaterUserRequest
{
    public required string PasswordHash { get; set; }
}