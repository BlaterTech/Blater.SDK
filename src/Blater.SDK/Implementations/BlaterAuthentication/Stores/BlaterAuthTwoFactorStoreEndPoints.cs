using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication.Stores;

public class BlaterAuthTwoFactorStoreEndPoints(BlaterHttpClient client) : IBlaterAuthTwoFactorStore
{
    private static string Endpoint => "/v1/Auth/2fa";
    
    public Task<BlaterResult<BlaterUser>> EnableTwoFactor(BlaterUser user, string id, string secret)
    {
        return client.Post<BlaterUser>($"{Endpoint}/enabled/{user.Email}/{id}/{secret}");
    }
    
    public Task<BlaterResult<BlaterUser>> DisableTwoFactor(BlaterUser user, string code)
    {
        return client.Post<BlaterUser>($"{Endpoint}/disabled/{user.Email}/{code}");
    }
    
    public Task<BlaterResult<bool>> VerifyOtpCode(string code)
    {
        return client.Get<bool>($"{Endpoint}/verify-otp-code/{code}");
    }
}