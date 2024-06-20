using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthLoginRepositoryEndPoints(BlaterHttpClient client) : IBlaterAuthLoginRepository
{
    private static string Endpoint => "/v1/";
    
    public Task<BlaterResult<BlaterUser>> AddLogin(BlaterUser user, BlaterLoginInfo login)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<BlaterUser>> RemoveLogin(BlaterUser user, string loginProvider, string providerKey)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<IEnumerable<BlaterLoginInfo>>> GetLogins(BlaterId id)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<BlaterUser>> FindByLogin(string loginProvider, string providerKey)
    {
        throw new NotImplementedException();
    }
}