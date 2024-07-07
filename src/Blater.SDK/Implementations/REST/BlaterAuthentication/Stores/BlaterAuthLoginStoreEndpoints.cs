using Blater.Models.User;
using Blater.Results;
using Blater.SDK.Contracts.Authentication.Request;
using Blater.SDK.Contracts.Common.Request;

namespace Blater.SDK.Implementations.REST.BlaterAuthentication.Stores;

public class BlaterAuthLoginStoreEndpoints(BlaterHttpClient client) : IBlaterAuthLoginStoreEndpoints
{
    private static string Endpoint => "/v1/Auth/login";

    public async Task<BlaterResult<string>> LoginLocal(AuthRequest request)
    {
        var result = await client.Post<string>($"{Endpoint}/local", request);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        if (string.IsNullOrWhiteSpace(response))
        {
            return BlaterErrors.NotFound;
        }

        BlaterHttpClient.Token = response;

        return response;
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