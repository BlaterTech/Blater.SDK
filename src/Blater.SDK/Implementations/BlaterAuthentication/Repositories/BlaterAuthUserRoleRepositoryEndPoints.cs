using Blater.Exceptions;
using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Models.User;
using Blater.SDK.Implementations.BlaterAuthentication.Stores;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthUserRoleRepositoryEndPoints(BlaterAuthUserRoleStoreEndPoints storeEndPoints) : IBlaterAuthUserRoleRepository
{
    public async Task<BlaterUser> AddToRole(string userId, string roleName)
    {
        var result = await storeEndPoints.AddToRole(userId, roleName);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        if (response == null)
        {
            throw new BlaterException("Error while adding user to role");
        }
        
        return response;
    }
    
    public async Task<BlaterUser> AddToRole(BlaterUser user, BlaterRole role)
    {
        var result = await storeEndPoints.AddToRole(user, role);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        if (response == null)
        {
            throw new BlaterException("Error while adding user to role");
        }
        
        return response;
    }
    
    public async Task<BlaterUser> RemoveFromRole(string userId, string roleName)
    {
        var result = await storeEndPoints.RemoveFromRole(userId, roleName);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        if (response == null)
        {
            throw new BlaterException("Error removing user from role");
        }
        
        return response;
    }
    
    public async Task<BlaterUser> RemoveFromRole(BlaterUser user, BlaterRole role)
    {
        var result = await storeEndPoints.RemoveFromRole(user, role);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        if (response == null)
        {
            throw new BlaterException("Error removing user from role");
        }
        
        return response;
    }
    
    public async Task<bool> IsInRole(string userId, string roleName)
    {
        var result = await storeEndPoints.IsInRole(userId, roleName);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async Task<bool> IsInRole(BlaterUser user, BlaterRole role)
    {
        var result = await storeEndPoints.IsInRole(user, role);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async Task<IReadOnlyList<BlaterRole>> GetRoles(BlaterUser user)
    {
        var result = await storeEndPoints.GetRoles(user);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        if (response == null)
        {
            throw new BlaterException("Error while getting roles");
        }
        
        return response;
    }
    
    public async Task<IReadOnlyList<string>> GetRoleNames(BlaterUser user)
    {
        var result = await storeEndPoints.GetRoleNames(user);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        if (response == null)
        {
            throw new BlaterException("Error while getting roles");
        }
        
        return response;
    }
    
    public async Task<IReadOnlyList<BlaterUser>> GetUsersInRole(string roleName)
    {
        var result = await storeEndPoints.GetUsersInRole(roleName);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        if (response == null)
        {
            throw new BlaterException("Error while getting users in role");
        }
        
        return response;
    }
    
    public async Task<IReadOnlyList<BlaterUser>> GetUsersInRole(BlaterRole role)
    {
        var result = await storeEndPoints.GetUsersInRole(role);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        if (response == null)
        {
            throw new BlaterException("Error while getting users in role");
        }
        
        return response;
    }
    
    public async Task<bool> IsInPermission(string userId, string permissionName)
    {
        var result = await storeEndPoints.IsInPermission(userId, permissionName);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async Task<bool> IsInPermission(BlaterUser user, BlaterPermission permission)
    {
        var result = await storeEndPoints.IsInPermission(user, permission);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async Task<IReadOnlyList<string>> GetPermissions(BlaterUser user)
    {
        var result = await storeEndPoints.GetPermissions(user);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        if (response == null)
        {
            throw new BlaterException("Error while getting permissions");
        }
        
        return response;
    }
    
    public async Task<IReadOnlyList<BlaterUser>> GetUsersInPermission(string permissionName)
    {
        var result = await storeEndPoints.GetUsersInPermission(permissionName);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        if (response == null)
        {
            throw new BlaterException("Error while getting users in permission");
        }
        
        return response;
    }
    
    public async Task<IReadOnlyList<BlaterUser>> GetUsersInPermission(BlaterPermission permission)
    {
        var result = await storeEndPoints.GetUsersInPermission(permission);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        if (response == null)
        {
            throw new BlaterException("Error while getting users in permission");
        }
        
        return response;
    }
}