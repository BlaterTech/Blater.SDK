using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Models.User;
using Blater.Query.Models;
using Blater.SDK.Implementations.BlaterAuthentication.Stores;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthRoleRepositoryEndPoints(BlaterAuthRoleStoreEndPoints storeEndPoints) : IBlaterAuthRoleRepository
{
    private static string Endpoint => "/v1/Role";
    
    
    public Task<BlaterRole> Create(BlaterRole role)
    {
        return storeEndPoints.Post<BlaterRole>($"{Endpoint}/create", role);
    }
    
    public Task<BlaterRole> Update(BlaterRole role)
    {
        return storeEndPoints.Put<BlaterRole>($"{Endpoint}/update", role);
    }
    
    public Task<bool> Delete(BlaterId id)
    {
        return storeEndPoints.Post<bool>($"{Endpoint}/delete", id);
    }
    
    public Task<bool> Delete(BlaterQuery query)
    {
        return storeEndPoints.Post<bool>($"{Endpoint}/delete-by-query", query);
    }
    
    public Task<bool> Delete(BlaterRole role)
    {
        return storeEndPoints.Post<bool>($"{Endpoint}/delete-by-id/{role.Id}");
    }
    
    public Task<BlaterRole> GetById(BlaterId id)
    {
        return storeEndPoints.Get<BlaterRole>($"{Endpoint}/get-by-id/{id}");
    }
    
    public Task<BlaterRole> GetByName(string roleName)
    {
        return storeEndPoints.Get<BlaterRole>($"{Endpoint}/get-by-name/{roleName}");
    }
    
    public Task<IReadOnlyList<BlaterRole>> GetPermissions(string permissionName)
    {
        return storeEndPoints.Get<IReadOnlyList<BlaterRole>>($"{Endpoint}/get-permissions/{permissionName}");
    }
}