using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Models.User;
using Blater.SDK.Implementations.BlaterAuthentication.Stores;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthEmailRepositoryEndPoints(BlaterAuthEmailStoreEndPoints storeEndPoints) : IBlaterAuthEmailRepository
{
    private static string Endpoint => "/v1/Auth";
    
    public async Task<BlaterUser> FindByEmail(string email)
    {
        return await storeEndPoints.FindByEmail(email);
    }
    
    public async Task<BlaterUser> SetConfirmEmail(string email)
    {
        return await storeEndPoints.Get<BlaterUser>($"{Endpoint}/confirmEmail/{email}");
    }
}