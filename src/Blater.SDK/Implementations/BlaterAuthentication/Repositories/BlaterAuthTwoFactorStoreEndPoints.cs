using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Models.User;
using Blater.SDK.Implementations.BlaterAuthentication.Stores;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterTwoFactorRoleRepositoryEndPoints(BlaterTwoFactorRoleStoreEndPoints storeEndPoints) : IBlaterAuthTwoFactorRepository
{
    
    public Task<BlaterUser> EnableTwoFactor(BlaterUser user, string id, string secret)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterUser> DisableTwoFactor(BlaterUser user, string code)
    {
        throw new NotImplementedException();
    }
    
    public Task<bool> VerifyOtpCode(string code)
    {
        throw new NotImplementedException();
    }
}