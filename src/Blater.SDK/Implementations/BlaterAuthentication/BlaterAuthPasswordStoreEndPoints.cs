using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication;

public class BlaterAuthPasswordStoreEndPoints(BlaterHttpClient client) : IBlaterAuthPasswordStore
{
    private static string Endpoint => "/v1/";
    
    
    public Task<BlaterResult<BlaterUser>> SetPasswordHash(BlaterUser user, string? passwordHash)
    {
        throw new NotImplementedException();
    }
}