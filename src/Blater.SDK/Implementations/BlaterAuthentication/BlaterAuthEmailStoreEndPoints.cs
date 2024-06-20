using Blater.Interfaces.BlaterAuthentication;
using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication;

public class BlaterAuthEmailStoreEndPoints(BlaterHttpClient client) : IBlaterAuthEmailStore
{
    private static string Endpoint => "/v1/Auth";
    public Task SetEmail(BlaterUser user, string? email)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<string>> GetEmail(BlaterUser user)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<bool>> GetEmailConfirmed(BlaterUser user)
    {
        return client.Get<bool>($"{Endpoint}/confirmEmail/{user.Email}");
    }
    
    public Task SetEmailConfirmed(BlaterUser user, bool confirmed)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<BlaterUser?>> FindByEmail(string email)
    {
        throw new NotImplementedException();
    }
}