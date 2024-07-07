using Blater.Models.User;
using Blater.Results;
using Blater.SDK.Contracts.Common.Request;

namespace Blater.SDK.Implementations.REST.BlaterAuthentication.Stores;

public class BlaterAuthEmailStoreEndpoints(BlaterHttpClient client) : IBlaterAuthEmailStoreEndpoints
{
    private static string Endpoint => "/v1/Auth";

    public Task<BlaterResult<BlaterUser>> FindByEmail(string email)
    {
        return client.Get<BlaterUser>($"{Endpoint}/find-by-email/{email}");
    }

    public Task<BlaterResult<bool>> ResetEmail(string email, ResetBlaterUserEmailRequest request)
    {
        return client.Post<bool>($"{Endpoint}/resetEmail/{email}", request);
    }

    public Task<BlaterResult<BlaterUser>> SetEmailConfirmed(BlaterUser user)
    {
        return client.Get<BlaterUser>($"{Endpoint}/confirmEmail/{user.Email}");
    }
}