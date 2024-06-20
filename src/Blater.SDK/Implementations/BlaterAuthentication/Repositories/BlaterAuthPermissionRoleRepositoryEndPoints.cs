using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Models.User;
using Blater.Results;
using Blater.SDK.Implementations.BlaterAuthentication.Stores;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthPermissionRoleRepositoryEndPoints(BlaterAuthPermissionRoleStoreEndPoints storeEndPoints) : IBlaterAuthPermissionRoleRepository
{
    private static string Endpoint => "/v1/PermissionRole";
    
    public Task<BlaterResult<BlaterRole>> AddToRole(BlaterRole role, BlaterPermission permission)
    {
        return storeEndPoints.Post<BlaterRole>($"{Endpoint}/add-to-role/{permission.Name}", role);
    }
    
    public Task<BlaterResult<BlaterRole>> AddToRole(string roleName, string permissionName)
    {
        return storeEndPoints.Post<BlaterRole>($"{Endpoint}/add-to-role/{roleName}/{permissionName}");
    }
    
    public Task<BlaterResult<BlaterRole>> RemoveFromRole(BlaterRole role, BlaterPermission permission)
    {
        return storeEndPoints.Post<BlaterRole>($"{Endpoint}/remove-from-role/{permission.Name}", role);
    }
    
    public Task<BlaterResult<BlaterRole>> RemoveFromRole(string roleName, string permissionName)
    {
        return storeEndPoints.Delete<BlaterRole>($"{Endpoint}/remove-from-role-with-name/{roleName}/{permissionName}");
    }
    
    public Task<IReadOnlyList<BlaterRole>> GetRoles(string permissionName)
    {
        return storeEndPoints.Get<IReadOnlyList<BlaterRole>>($"{Endpoint}/get-roles/{permissionName}");
    }
}