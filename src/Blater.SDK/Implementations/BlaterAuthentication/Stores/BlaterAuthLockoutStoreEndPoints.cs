using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication.Stores;

public class BlaterAuthLockoutStoreEndPoints(BlaterHttpClient client) : IBlaterAuthLockoutStore
{
    private static string Endpoint => "/v1/";
    
    public Task<BlaterResult<BlaterUser>> SetLockoutEndDate(BlaterUser user, DateTimeOffset? lockoutEnd)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<int>> IncrementAccessFailedCount(BlaterUser user)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<BlaterUser>> ResetAccessFailedCount(BlaterUser user)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<BlaterUser>> SetLockoutEnabled(BlaterUser user, bool enabled)
    {
        throw new NotImplementedException();
    }
}