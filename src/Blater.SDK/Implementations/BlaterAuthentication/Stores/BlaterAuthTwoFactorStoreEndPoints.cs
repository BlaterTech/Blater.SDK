﻿using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication.Stores;

public class BlaterTwoFactorRoleStoreEndPoints(BlaterHttpClient client) : IBlaterAuthTwoFactorStore
{
    private static string Endpoint => "/v1/Auth/2fa";
    
    public Task<BlaterResult<BlaterUser>> EnableTwoFactor(BlaterUser user, string id, string secret)
    {
        return client.Get<BlaterUser>($"{Endpoint}/2fa/{email}/{enabled}");
    }
    
    public Task<BlaterResult<BlaterUser>> DisableTwoFactor(BlaterUser user, string code)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<bool>> VerifyOtpCode(string code)
    {
        throw new NotImplementedException();
    }
}