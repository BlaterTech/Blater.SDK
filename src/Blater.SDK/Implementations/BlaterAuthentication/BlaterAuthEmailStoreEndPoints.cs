using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication;

public class BlaterAuthEmailStoreEndPoints(BlaterHttpClient client) : IBlaterAuthEmailStore
{
    private static string Endpoint => "/v1/Auth";
    
    public async Task<BlaterResult<BlaterUser?>> FindByEmail(string email)
    {
        return await client.Get<BlaterUser?>($"{Endpoint}/find-by-email/{email}");
    }
}