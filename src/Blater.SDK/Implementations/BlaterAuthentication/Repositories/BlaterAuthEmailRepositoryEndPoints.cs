using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthEmailRepositoryEndPoints(BlaterHttpClient client) : IBlaterAuthEmailRepository
{
    private static string Endpoint => "/v1/Auth";
    
    public async Task<BlaterResult<BlaterUser?>> FindByEmail(string email)
    {
        return await client.Get<BlaterUser?>($"{Endpoint}/find-by-email/{email}");
    }
    
    public async Task<BlaterResult<BlaterUser?>> SetConfirmEmail(string email)
    {
        return await client.Get<BlaterUser?>($"{Endpoint}/confirmEmail/{email}");
    }
}