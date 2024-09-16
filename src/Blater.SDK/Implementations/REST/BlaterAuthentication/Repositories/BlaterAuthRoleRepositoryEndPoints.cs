using System.Linq.Expressions;
using Blater.Exceptions;
using Blater.Models.User;

namespace Blater.SDK.Implementations.REST.BlaterAuthentication.Repositories;

public class BlaterAuthRoleRepositoryEndPoints(IBlaterAuthRoleStore storeEndPoints) : IBlaterAuthRoleRepository
{
    public async Task<BlaterRole> Create(BlaterRole role)
    {
        var result = await storeEndPoints.Create(role);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error creating role");
        }

        return response;
    }

    public async Task<BlaterRole> Update(BlaterRole role)
    {
        var result = await storeEndPoints.Update(role);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error updating role");
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

    public async Task<bool> Delete(Expression<Func<BlaterRole, bool>> predicate)
    {
        var query = predicate.ExpressionToBlaterQuery();

        var result = await storeEndPoints.Delete(query);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }

    public async Task<bool> Delete(BlaterRole role)
    {
        var result = await storeEndPoints.Delete(role);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }

    public async Task<BlaterRole> GetById(BlaterId id)
    {
        var result = await storeEndPoints.GetById(id);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error getting role by id");
        }

        return response;
    }

    public async Task<BlaterRole> GetByName(string roleName)
    {
        var result = await storeEndPoints.GetByName(roleName);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error getting role by name");
        }

        return response;
    }

    public async Task<IReadOnlyList<BlaterRole>> GetPermissions(string permissionName)
    {
        var result = await storeEndPoints.GetPermissions(permissionName);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error getting role by name");
        }

        return response;
    }
}