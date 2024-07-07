using Blater.Exceptions;
using Blater.Models.User;

namespace Blater.SDK.Implementations.REST.BlaterAuthentication.Repositories;

public class BlaterAuthUserPermissionsRepositoryEndPoints(IBlaterAuthUserPermissionStore storeEndPoints) : IBlaterAuthUserPermissionRepository
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