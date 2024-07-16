using Blater.Exceptions;
using Blater.Models.User;
using Blater.SDK.Contracts.Authentication.Request;
using Blater.SDK.Interfaces.BlaterAuth;

namespace Blater.SDK.Implementations;

public class BlaterSDK(IBlaterAuthLoginStoreEndpoints loginStore, BlaterAuthState authState) : IBlaterSDK
{
    public async Task Login(string email, string password)
    {
        var response = await loginStore.LoginLocal(new AuthRequest
        {
            Email = email,
            Password = password
        });
        
        if(response.HandleErrors(out var errors, out var user))
        {
            throw new BlaterException(errors);
        }
        
        authState.JwtToken = user;
    }

    public Task Login(string token)
    {
        authState.JwtToken = token;
        return Task.CompletedTask;
    }
}