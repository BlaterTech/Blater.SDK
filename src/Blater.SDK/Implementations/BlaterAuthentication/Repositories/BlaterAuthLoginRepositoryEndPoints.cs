using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Models.User;
using Blater.SDK.Implementations.BlaterAuthentication.Stores;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthLoginRepositoryEndPoints(BlaterAuthLoginStoreEndPoints storeEndPoints) : IBlaterAuthLoginRepository
{
    private static string Endpoint => "/v1/";
    
    public Task<BlaterUser> AddLogin(BlaterUser user, BlaterLoginInfo login)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterUser> RemoveLogin(BlaterUser user, string loginProvider, string providerKey)
    {
        throw new NotImplementedException();
    }
    
    public Task<IEnumerable<BlaterLoginInfo>> GetLogins(BlaterId id)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterUser> FindByLogin(string loginProvider, string providerKey)
    {
        throw new NotImplementedException();
    }
}