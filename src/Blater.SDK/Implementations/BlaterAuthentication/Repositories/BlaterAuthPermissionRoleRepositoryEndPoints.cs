using Blater.Exceptions;
using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Models.User;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthPermissionRoleRepositoryEndPoints(IBlaterAuthPermissionRoleStore storeEndPoints) : IBlaterAuthPermissionRoleRepository
{
    public async Task<BlaterRole> AddToRole(BlaterRole role, BlaterPermission permission)
    {
        var result = await storeEndPoints.AddToRole(role, permission);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error while adding to role");
        }

        return response;
    }

    public async Task<BlaterRole> AddToRole(string roleName, string permissionName)
    {
        var result = await storeEndPoints.AddToRole(roleName, permissionName);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error while adding to role");
        }

        return response;
    }

    public async Task<BlaterRole> RemoveFromRole(BlaterRole role, BlaterPermission permission)
    {
        var result = await storeEndPoints.RemoveFromRole(role, permission);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error removing from role");
        }

        return response;
    }

    public async Task<BlaterRole> RemoveFromRole(string roleName, string permissionName)
    {
        var result = await storeEndPoints.RemoveFromRole(roleName, permissionName);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error removing from role");
        }

        return response;
    }

    public async Task<IReadOnlyList<BlaterRole>> GetRoles(string permissionName)
    {
        var result = await storeEndPoints.GetRoles(permissionName);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error removing from role");
        }

        return response;
    }
}