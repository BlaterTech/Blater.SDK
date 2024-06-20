using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Models.User;
using Blater.Query.Models;
using Blater.SDK.Implementations.BlaterAuthentication.Stores;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthPermissionRepositoryEndPoints(BlaterAuthPermissionRoleStoreEndPoints storeEndPoints) : IBlaterAuthPermissionRepository
{
    private static string Endpoint => "/v1/Permission";
    
    public Task<BlaterPermission> Create(BlaterPermission permission)
    {
        return storeEndPoints.Post<BlaterPermission>($"{Endpoint}/", permission);
    }
    
    public Task<BlaterPermission> Update(BlaterPermission permission)
    {
        return storeEndPoints.Put<BlaterPermission>($"{Endpoint}/", permission);
    }
    
    public Task<bool> Delete(BlaterPermission permission)
    {
        return storeEndPoints.Delete<bool>($"{Endpoint}/{permission.Id}");
    }
    
    public Task<bool> Delete(BlaterId id)
    {
        //return client.Delete<bool>($"{Endpoint}/{id}");
        throw new NotImplementedException();
    }
    
    public Task<bool> Delete(BlaterQuery query)
    {
        throw new NotImplementedException();
    }
    
    public Task<IReadOnlyList<BlaterPermission>> GetAll()
    {
        return storeEndPoints.Get<IReadOnlyList<BlaterPermission>>($"{Endpoint}/");
    }
    
    public Task<BlaterPermission> GetById(BlaterId id)
    {
        //return client.Get<BlaterPermission>($"{Endpoint}/{id}");
        throw new NotImplementedException();
    }
    
    public Task<BlaterPermission> GetPermission(string permissionName)
    {
        //return client.Get<BlaterPermission>($"{Endpoint}/Permission/{permissionName}");
        throw new NotImplementedException();
    }
}