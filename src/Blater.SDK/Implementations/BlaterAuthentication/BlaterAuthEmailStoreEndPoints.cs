using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication;

public class BlaterAuthEmailStoreEndPoints(BlaterHttpClient client) : IBlaterAuthEmailStore
{
    private static string Endpoint => "/v1/Auth";
    
    public Task<BlaterResult<BlaterUser>> SetEmail(BlaterUser user, string? email)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<BlaterUser>> SetEmailConfirmed(BlaterUser user, bool confirmed)
    {
        return client.Get<BlaterUser>($"{Endpoint}/confirmEmail/{user.Email}");
    }
    
    public Task<BlaterResult<BlaterUser?>> FindByEmail(string email)
    {
        throw new NotImplementedException();
    }
}