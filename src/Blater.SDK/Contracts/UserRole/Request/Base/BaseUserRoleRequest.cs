using Blater.Models.User;

namespace Blater.SDK.Contracts.UserRole.Request.Base;

public abstract class BaseUserRoleRequest
{
    public required BlaterUser BlaterUser { get; set; }
    public required string RoleName { get; set; }
}