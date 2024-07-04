using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Models.User;
using Blater.Query.Models;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication.Stores;

public class BlaterAuthPermissionStoreEndPoints(BlaterHttpClient client) : IBlaterAuthPermissionStore
{
    private static string Endpoint => "/v1/Permission";

    public async Task<BlaterResult<BlaterPermission>> Create(BlaterPermission permission)
    {
        var result = await client.Post<BlaterPermission>($"{Endpoint}", permission);
        return result;
    }

    public Task<BlaterResult<BlaterPermission>> Update(BlaterPermission permission)
    {
        return client.Put<BlaterPermission>($"{Endpoint}", permission);
    }

    public Task<BlaterResult<bool>> Delete(BlaterPermission permission)
    {
        return client.Delete<bool>($"{Endpoint}/{permission.Id}");
    }

    public Task<BlaterResult<bool>> Delete(BlaterId id)
    {
        return client.Delete<bool>($"{Endpoint}/{id}");
    }

    public Task<BlaterResult<bool>> Delete(BlaterQuery query)
    {
        return client.Post<bool>($"{Endpoint}/delete-by-query", query);
    }

    public Task<BlaterResult<IReadOnlyList<BlaterPermission>>> GetAll()
    {
        return client.Get<IReadOnlyList<BlaterPermission>>($"{Endpoint}");
    }

    public Task<BlaterResult<BlaterPermission>> GetById(BlaterId id)
    {
        return client.Get<BlaterPermission>($"{Endpoint}/get-by-id/{id}");
    }

    public Task<BlaterResult<BlaterPermission>> GetPermission(string permissionName)
    {
        return client.Get<BlaterPermission>($"{Endpoint}/get-by-name/{permissionName}");
    }
}