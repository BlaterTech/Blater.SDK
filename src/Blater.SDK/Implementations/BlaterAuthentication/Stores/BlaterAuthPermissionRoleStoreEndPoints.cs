using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication.Stores;

public class BlaterAuthPermissionRoleStoreEndPoints(BlaterHttpClient client) : IBlaterAuthPermissionRoleStore
{
    private static string Endpoint => "/v1/PermissionRole";
    
    public Task<BlaterResult<BlaterRole>> AddToRole(BlaterRole role, BlaterPermission permission)
    {
        return client.Post<BlaterRole>($"{Endpoint}/add-to-role/{permission.Name}", role);
    }
    
    public Task<BlaterResult<BlaterRole>> AddToRole(string roleName, string permissionName)
    {
        return client.Post<BlaterRole>($"{Endpoint}/add-to-role/{roleName}/{permissionName}");
    }
    
    public Task<BlaterResult<BlaterRole>> RemoveFromRole(BlaterRole role, BlaterPermission permission)
    {
        return client.Post<BlaterRole>($"{Endpoint}/remove-from-role/{permission.Name}", role);
    }
    
    public Task<BlaterResult<BlaterRole>> RemoveFromRole(string roleName, string permissionName)
    {
        return client.Delete<BlaterRole>($"{Endpoint}/remove-from-role-with-name/{roleName}/{permissionName}");
    }
    
    public Task<BlaterResult<IReadOnlyList<BlaterRole>>> GetRoles(string permissionName)
    {
        return client.Get<IReadOnlyList<BlaterRole>>($"{Endpoint}/get-roles/{permissionName}");
    }
}