using Blater.Exceptions;
using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Models.User;
using Blater.SDK.Implementations.BlaterAuthentication.Stores;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthEmailRepositoryEndPoints(BlaterAuthEmailStoreEndPoints storeEndPoints) : IBlaterAuthEmailRepository
{
    public async Task<BlaterUser> FindByEmail(string email)
    {
        var result = await storeEndPoints.FindByEmail(email);
        
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
    
    public async Task<BlaterUser> SetConfirmEmail(BlaterUser user)
    {
        var result = await storeEndPoints.SetEmailConfirmed(user);
        
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