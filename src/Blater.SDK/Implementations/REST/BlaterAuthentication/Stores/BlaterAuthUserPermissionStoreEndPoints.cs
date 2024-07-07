using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.REST.BlaterAuthentication.Stores;

public class BlaterAuthUserPermissionStoreEndPoints(BlaterHttpClient client) : IBlaterAuthUserPermissionStore
{
    private static string Endpoint => "/v1/UserPermission";

    public Task<BlaterResult<bool>> IsInPermission(string userId, string permissionName)
    {
        return client.Get<bool>($"{Endpoint}/is-in-permission/{userId}/{permissionName}");
    }

    public Task<BlaterResult<bool>> IsInPermission(BlaterUser user, BlaterPermission permission)
    {
        return client.Post<bool>($"{Endpoint}/is-in-permission/{permission.Name}", user);
    }

    public Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInPermission(string permissionName)
    {
        return client.Get<IReadOnlyList<BlaterUser>>($"{Endpoint}/get-users-in-permission/{permissionName}");
    }

    public Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInPermission(BlaterPermission permission)
    {
        return client.Post<IReadOnlyList<BlaterUser>>($"{Endpoint}/get-users-in-permission", permission);
    }
}