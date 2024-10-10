using Blater.Models.User;
using Blater.Results;

namespace Blater.SDK.Implementations.REST.BlaterAuthentication.Stores;

public class BlaterAuthRoleStoreEndPoints(BlaterHttpClient client) : IBlaterAuthRoleStore
{
    private static string Endpoint => "/v1/Role";

    public Task<BlaterResult<BlaterRole>> Create(BlaterRole role)
    {
        return client.Post<BlaterRole>($"{Endpoint}/create", role);
    }

    public Task<BlaterResult<BlaterRole>> Update(BlaterRole role)
    {
        return client.Put<BlaterRole>($"{Endpoint}/update", role);
    }

    public Task<BlaterResult<bool>> Delete(BlaterId id)
    {
        return client.Delete<bool>($"{Endpoint}/{id}");
    }

    public Task<BlaterResult<bool>> Delete(BlaterQuery query)
    {
        return client.Post<bool>($"{Endpoint}/delete-by-query", query);
    }

    public Task<BlaterResult<bool>> Delete(BlaterRole role)
    {
        return client.Post<bool>($"{Endpoint}/delete", role);
    }

    public Task<BlaterResult<BlaterRole>> GetById(BlaterId id)
    {
        return client.Get<BlaterRole>($"{Endpoint}/get-by-id/{id}");
    }

    public Task<BlaterResult<BlaterRole>> GetByName(string roleName)
    {
        return client.Get<BlaterRole>($"{Endpoint}/get-by-name/{roleName}");
    }

    public Task<BlaterResult<IReadOnlyList<BlaterRole>>> GetPermissions(string permissionName)
    {
        return client.Get<IReadOnlyList<BlaterRole>>($"{Endpoint}/get-permissions/{permissionName}");
    }
}