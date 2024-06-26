using Blater.Exceptions;
using Blater.Models.User;
using Blater.SDK.Contracts.Common.Request;
using Blater.SDK.Implementations.BlaterAuthentication.Stores;
using Blater.SDK.Interfaces;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthEmailRepositoryEndpoints(IBlaterAuthEmailStoreEndpoints storeEndpointsEndPoints) : IBlaterAuthEmailRepositoryEndpoints
{
    public async Task<BlaterUser> FindByEmail(string email)
    {
        var result = await storeEndpointsEndPoints.FindByEmail(email);
        
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

    public async Task<bool> ResetEmail(string email, ResetBlaterUserEmailRequest request)
    {
        var result = await storeEndpointsEndPoints.ResetEmail(email, request);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }

    public async Task<BlaterUser> SetEmailConfirmed(BlaterUser user)
    {
        var result = await storeEndpointsEndPoints.SetEmailConfirmed(user);
        
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