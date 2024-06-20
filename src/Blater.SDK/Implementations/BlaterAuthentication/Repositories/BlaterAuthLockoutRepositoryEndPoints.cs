using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Models.User;
using Blater.SDK.Implementations.BlaterAuthentication.Stores;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthLockoutRepositoryEndPoints(BlaterAuthLockoutStoreEndPoints storeEndPoints) : IBlaterAuthLockoutRepository
{
    private static string Endpoint => "/v1/";
    
    public Task<BlaterUser> SetLockoutEndDate(BlaterUser user, DateTimeOffset? lockoutEnd)
    {
        throw new NotImplementedException();
    }
    
    public Task<int> IncrementAccessFailedCount(BlaterUser user)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterUser> ResetAccessFailedCount(BlaterUser user)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterUser> SetLockoutEnabled(BlaterUser user, bool enabled)
    {
        throw new NotImplementedException();
    }
}