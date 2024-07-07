using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.REST.BlaterAuthentication.Stores;

public class BlaterAuthLockoutStoreEndPoints(BlaterHttpClient client) : IBlaterAuthLockoutStore
{
    private static string Endpoint => "/v1/Auth/lockout";

    public Task<BlaterResult<BlaterUser>> SetLockoutEndDate(BlaterUser user, DateTimeOffset? lockoutEnd)
    {
        return client.Post<BlaterUser>($"{Endpoint}/set-lockout-endDate/{lockoutEnd}", user);
    }

    public Task<BlaterResult<int>> IncrementAccessFailedCount(BlaterUser user)
    {
        return client.Post<int>($"{Endpoint}/increment-access-failed", user);
    }

    public Task<BlaterResult<BlaterUser>> ResetAccessFailedCount(BlaterUser user)
    {
        return client.Post<BlaterUser>($"{Endpoint}/reset-access-failed", user);
    }

    public Task<BlaterResult<BlaterUser>> SetLockoutEnabled(BlaterUser user, bool enabled)
    {
        return client.Post<BlaterUser>($"{Endpoint}/set-lockout-enabled/{enabled}", user);
    }
}