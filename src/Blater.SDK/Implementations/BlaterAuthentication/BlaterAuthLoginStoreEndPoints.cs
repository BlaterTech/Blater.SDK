/*using Blater.Interfaces.BlaterAuthentication;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication;

public class BlaterAuthLoginStoreEndPoints(BlaterHttpClient client) : IBlaterAuthLoginStore
{
    private static string Endpoint => "/v1/";
    
    public Task AddLogin(BlaterUser user, BlaterLoginInfo login)
    {
        throw new NotImplementedException();
    }
    
    public Task RemoveLogin(BlaterUser user, string loginProvider, string providerKey)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<IEnumerable<BlaterLoginInfo>>> GetLogins(BlaterUser user)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<BlaterUser>> FindByLogin(string loginProvider, string providerKey)
    {
        throw new NotImplementedException();
    }
}*/