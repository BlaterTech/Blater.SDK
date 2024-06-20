using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication.Stores;

public class BlaterAuthUserPermissionStoreEndPoints : IBlaterAuthUserPermissionStore
{
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