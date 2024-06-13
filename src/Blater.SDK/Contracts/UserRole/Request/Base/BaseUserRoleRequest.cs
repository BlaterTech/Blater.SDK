using Blater.Models.User;

namespace Blater.SDK.Contracts.UserRole.Request.Base;

public abstract class BaseUserRoleRequest
{
    public required BaseBlaterUser BaseBlaterUser { get; set; }
    public required BaseBlaterRole BaseBlaterRole { get; set; }
}