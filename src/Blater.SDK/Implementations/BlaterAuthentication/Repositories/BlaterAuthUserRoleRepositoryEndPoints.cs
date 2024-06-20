using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Models.User;
using Blater.SDK.Implementations.BlaterAuthentication.Stores;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthUserRoleRepositoryEndPoints(BlaterAuthUserRoleStoreEndPoints storeEndPoints) : IBlaterAuthUserRoleRepository
{
    private static string Endpoint => "/v1/UserRole";
    
    public Task<BlaterUser> AddToRole(string userId, string roleName)
    {
        return storeEndPoints.Post<BlaterUser>($"{Endpoint}/add-to-role-with-name/{userId}/{roleName}");
    }
    
    public Task<BlaterUser> AddToRole(BlaterUser user, BlaterRole role)
    {
        return storeEndPoints.Post<BlaterUser>($"{Endpoint}/add-to-role/{role.Name}", user);
    }
    
    public Task<BlaterUser> RemoveFromRole(string userId, string roleName)
    {
        return storeEndPoints.Delete<BlaterUser>($"{Endpoint}/remove-from-role-with-name/{userId}/{roleName}");
    }
    
    public Task<BlaterUser> RemoveFromRole(BlaterUser user, BlaterRole role)
    {
        return storeEndPoints.Post<BlaterUser>($"{Endpoint}/remove-from-role/{role.Name}", user);
    }
    
    public Task<bool> IsInRole(string userId, string roleName)
    {
        return storeEndPoints.Get<bool>($"{Endpoint}/is-in-role-with-name/{userId}/{roleName}");
    }
    
    public Task<bool> IsInRole(BlaterUser user, BlaterRole role)
    {
        return storeEndPoints.Post<bool>($"{Endpoint}/is-in-role/{role.Name}", user);
    }
    
    public Task<IReadOnlyList<BlaterRole>> GetRoles(BlaterUser user)
    {
        return client.Post<IReadOnlyList<BlaterRole>>($"{Endpoint}/get-roles", user);
    }
    
    public Task<IReadOnlyList<string>> GetRoleNames(BlaterUser user)
    {
        return storeEndPoints.Post<IReadOnlyList<string>>($"{Endpoint}/get-role-names", user);
    }
    
    public Task<IReadOnlyList<BlaterUser>> GetUsersInRole(string roleName)
    {
        return storeEndPoints.Get<IReadOnlyList<BlaterUser>>($"{Endpoint}/get-users-in-role-with-name/{roleName}");
    }
    
    public Task<IReadOnlyList<BlaterUser>> GetUsersInRole(BlaterRole role)
    {
        //return client.Get<IReadOnlyList<BlaterUser>>($"{Endpoint}/get-users-in-role-with-name/{role.Name}");
        throw new NotImplementedException();
    }
    
    public Task<bool> IsInPermission(string userId, string permissionName)
    {
        throw new NotImplementedException();
    }
    
    public Task<bool> IsInPermission(BlaterUser user, BlaterPermission permission)
    {
        throw new NotImplementedException();
    }
    
    public Task<IReadOnlyList<string>> GetPermissions(BlaterUser user)
    {
        throw new NotImplementedException();
    }
    
    public Task<IReadOnlyList<BlaterUser>> GetUsersInPermission(string permissionName)
    {
        throw new NotImplementedException();
    }
    
    public Task<IReadOnlyList<BlaterUser>> GetUsersInPermission(BlaterPermission permission)
    {
        throw new NotImplementedException();
    }
}