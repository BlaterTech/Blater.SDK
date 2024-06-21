using Blater.Models.User;
using Blater.Results;
using Blater.SDK.Contracts.Authentication.Request;
using Blater.SDK.Contracts.Common.Request;
using IBlaterAuthLoginStore = Blater.SDK.Interfaces.IBlaterAuthLoginStore;

namespace Blater.SDK.Implementations.BlaterAuthentication.Stores;

public class BlaterAuthLoginStoreEndPoints(BlaterHttpClient client) : IBlaterAuthLoginStore
{
    private static string Endpoint => "/v1/Auth/login";

    public Task<BlaterResult<string>> LoginLocal(AuthRequest request)
    {
        return client.Post<string>($"{Endpoint}/local", request);
    }

    public Task<BlaterResult<BlaterUser>> Register(RegisterBlaterUserRequest request)
    {
        return client.Post<BlaterUser>($"{Endpoint}/register", request);
    }

    public Task<BlaterResult<BlaterUser>> AddLogin(BlaterUser user, BlaterLoginInfo login)
    {
        return client.Post<BlaterUser>($"{Endpoint}/add-login/{user.Id}", login);
    }
    
    public Task<BlaterResult<BlaterUser>> RemoveLogin(BlaterUser user, string loginProvider, string providerKey)
    {
        return client.Delete<BlaterUser>($"{Endpoint}/remove-login/{user.Id}/{loginProvider}/{providerKey}");
    }
    
    public Task<BlaterResult<IReadOnlyList<BlaterLoginInfo>>> GetLogins(BlaterId id)
    {
        return client.Get<IReadOnlyList<BlaterLoginInfo>>($"{Endpoint}/get-logins/{id}");
    }
    
    public Task<BlaterResult<BlaterUser>> FindByLogin(string loginProvider, string providerKey)
    {
        return client.Get<BlaterUser>($"{Endpoint}/find-by-login/{loginProvider}/{providerKey}");
    }
}