using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthLockoutRepositoryEndPoints(BlaterHttpClient client) : IBlaterAuthLockoutRepository
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