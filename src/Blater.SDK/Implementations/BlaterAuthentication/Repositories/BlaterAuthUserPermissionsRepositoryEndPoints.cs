using Blater.Exceptions;
using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Models.User;
using Blater.SDK.Implementations.BlaterAuthentication.Stores;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthUserPermissionsRepositoryEndPoints(BlaterAuthUserPermissionStoreEndPoints storeEndPoints) : IBlaterAuthUserPermissionRepository
{
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