/*using Blater.Interfaces.BlaterAuthentication;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication;

public class BlaterAuthEmailStoreEndPoints(BlaterHttpClient client) : IBlaterAuthLockoutStore
{
    private static string Endpoint => "/v1/";
    
    public Task<BlaterResult<DateTimeOffset>> GetLockoutEndDate(BlaterUser user)
    {
        throw new NotImplementedException();
    }
    
    public Task SetLockoutEndDate(BlaterUser user, DateTimeOffset? lockoutEnd)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<int>> IncrementAccessFailedCount(BlaterUser user)
    {
        throw new NotImplementedException();
    }
    
    public Task ResetAccessFailedCount(BlaterUser user)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<int>> GetAccessFailedCount(BlaterUser user)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<bool>> GetLockoutEnabled(BlaterUser user)
    {
        throw new NotImplementedException();
    }
    
    public Task SetLockoutEnabled(BlaterUser user, bool enabled)
    {
        throw new NotImplementedException();
    }
}*/