using Blater.Exceptions;
using Blater.Models.User;

using System.Linq.Expressions;

namespace Blater.SDK.Implementations.REST.BlaterAuthentication.Repositories;

public class BlaterAuthPermissionRepositoryEndPoints(IBlaterAuthPermissionStore storeEndPoints) : IBlaterAuthPermissionRepository
{
    public async Task<BlaterPermission> Create(BlaterPermission permission)
    {
        var result = await storeEndPoints.Create(permission);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error creating permission");
        }

        return response;
    }

    public async Task<BlaterPermission> Update(BlaterPermission permission)
    {
        var result = await storeEndPoints.Update(permission);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error updating permission");
        }

        return response;
    }

    public async Task<bool> Delete(BlaterPermission permission)
    {
        var result = await storeEndPoints.Delete(permission);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }

    public async Task<bool> Delete(BlaterId id)
    {
        var result = await storeEndPoints.Delete(id);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }

    public async Task<bool> Delete(Expression<Func<BlaterPermission, bool>> predicate)
    {
        var query = predicate.ExpressionToBlaterQuery();

        var result = await storeEndPoints.Delete(query);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }

    public async Task<IReadOnlyList<BlaterPermission>> GetAll()
    {
        var result = await storeEndPoints.GetAll();

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error getting all permissions");
        }

        return response;
    }

    public async Task<BlaterPermission> GetById(BlaterId id)
    {
        var result = await storeEndPoints.GetById(id);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error getting permission by id");
        }

        return response;
    }

    public async Task<BlaterPermission> GetPermission(string permissionName)
    {
        var result = await storeEndPoints.GetPermission(permissionName);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("No user found with that email");
        }

        return response;
    }
}