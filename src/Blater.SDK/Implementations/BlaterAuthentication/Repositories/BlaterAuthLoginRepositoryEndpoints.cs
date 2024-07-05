using Blater.Exceptions;
using Blater.Exceptions.Database;
using Blater.Models.User;
using Blater.SDK.Contracts.Authentication.Request;
using Blater.SDK.Contracts.Common.Request;
using Blater.SDK.Interfaces;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthLoginRepositoryEndpoints(IBlaterAuthLoginStoreEndpoints storeEndpointsEndPoints) : IBlaterAuthLoginRepositoryEndpoints
{
    public async Task<string> LoginLocal(AuthRequest request)
    {
        var result = await storeEndpointsEndPoints.LoginLocal(request);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response ?? string.Empty;
    }

    public async Task<BlaterUser> Register(RegisterBlaterUserRequest request)
    {
        var result = await storeEndpointsEndPoints.Register(request);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterDatabaseException("User not found");
        }

        return response;
    }

    public async Task<BlaterUser> AddLogin(BlaterUser user, BlaterLoginInfo login)
    {
        var result = await storeEndpointsEndPoints.AddLogin(user, login);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error while adding login");
        }

        return response;
    }

    public async Task<BlaterUser> RemoveLogin(BlaterUser user, string loginProvider, string providerKey)
    {
        var result = await storeEndpointsEndPoints.RemoveLogin(user, loginProvider, providerKey);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error while removing login");
        }

        return response;
    }

    public async Task<IReadOnlyList<BlaterLoginInfo>> GetLogins(BlaterId id)
    {
        var result = await storeEndpointsEndPoints.GetLogins(id);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error while getting logins");
        }

        return response;
    }

    public async Task<BlaterUser> FindByLogin(string loginProvider, string providerKey)
    {
        var result = await storeEndpointsEndPoints.FindByLogin(loginProvider, providerKey);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error while finding user by login");
        }

        return response;
    }
}