/*using Blater.Interfaces.BlaterAuthentication;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication;

public class BlaterAuthPasswordStoreEndPoints(BlaterHttpClient client) : IBlaterAuthPasswordStore
{
    private static string Endpoint => "/v1/";
    
    public Task SetPasswordHash(BlaterUser user, string? passwordHash)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<bool>> HasPassword(BlaterUser user)
    {
        throw new NotImplementedException();
    }
}*/