using Blater.Interfaces.BlaterAuthentication;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication;

public class BlaterAuthUserRoleStoreEndPoints(BlaterHttpClient client) : IBlaterAuthUserRoleStore
{
    private static string Endpoint => "/v1/UserRole";
    
    public Task<BlaterResult<BlaterUser>> AddToRole(string userId, string roleName)
    {
        return client.Post<BlaterUser>($"{Endpoint}/add-to-role-with-name/{userId}/{roleName}");
    }
    
    public Task<BlaterResult<BlaterUser>> AddToRole(BlaterUser user, BlaterRole role)
    {
        return client.Post<BlaterUser>($"{Endpoint}/add-to-role/{role.Name}", user);
    }
    
    public Task<BlaterResult<BlaterUser>> RemoveFromRole(string userId, string roleName)
    {
        return client.Delete<BlaterUser>($"{Endpoint}/remove-from-role-with-name/{userId}/{roleName}");
    }
    
    public Task<BlaterResult<BlaterUser>> RemoveFromRole(BlaterUser user, BlaterRole role)
    {
        return client.Post<BlaterUser>($"{Endpoint}/remove-from-role/{role.Name}", user);
    }
    
    public Task<BlaterResult<bool>> IsInRole(string userId, string roleName)
    {
        return client.Get<bool>($"{Endpoint}/is-in-role-with-name/{userId}/{roleName}");
    }
    
    public Task<BlaterResult<bool>> IsInRole(BlaterUser user, BlaterRole role)
    {
        return client.Post<bool>($"{Endpoint}/is-in-role/{role.Name}", user);
    }
    
    public Task<BlaterResult<IReadOnlyList<BlaterRole>>> GetRoles(BlaterUser user)
    {
        return client.Post<IReadOnlyList<BlaterRole>>($"{Endpoint}/get-roles", user);
    }
    
    public Task<BlaterResult<IReadOnlyList<string>>> GetRoleNames(BlaterUser user)
    {
        return client.Post<IReadOnlyList<string>>($"{Endpoint}/get-role-names", user);
    }
    
    public Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInRole(string roleName)
    {
        return client.Get<IReadOnlyList<BlaterUser>>($"{Endpoint}/get-users-in-role-with-name/{roleName}");
    }
    
    public Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInRole(BlaterRole role)
    {
        //return client.Get<IReadOnlyList<BlaterUser>>($"{Endpoint}/get-users-in-role-with-name/{role.Name}");
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<bool>> IsInPermission(string userId, string permissionName)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<bool>> IsInPermission(BlaterUser user, BlaterPermission permission)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<IReadOnlyList<string>>> GetPermissions(BlaterUser user)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInPermission(string permissionName)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInPermission(BlaterPermission permission)
    {
        throw new NotImplementedException();
    }
}