using Blater.Interfaces;
using Blater.Results;

namespace Blater.SDK.Implementations;

public class BlaterKeyValueRepositoryEndPoints(BlaterKeyValueStoreEndPoints storeEndPoints) : IBlaterKeyValueRepository
{
    private static string Endpoint => "/v1/KeyValue";
    public Task<TValue?> Get<TValue>(string key)
    {
        return storeEndPoints.Get<TValue?>($"{Endpoint}/{key}");
    }
    
    public Task<string?> Get(string key)
    {
        return storeEndPoints.Get<string?>($"{Endpoint}/{key}");
    }
    
    public Task<IReadOnlyList<string>> Get()
    {
        return storeEndPoints.Get<IReadOnlyList<string>>($"{Endpoint}");
    }
    
    public Task<bool> Set<TValue>(string key, TValue value)
    {
        if (value != null)
        {
            return storeEndPoints.Post<bool>($"{Endpoint}/{key}", value);
        }
        
        return new Task<bool>(() =>false);
    }
    
    public Task<bool> Set(string key, object value)
    {
        return storeEndPoints.Post<bool>($"{Endpoint}/{key}", value);
    }
    
    public Task<bool> Remove(string key)
    {
        return storeEndPoints.Delete<bool>($"{Endpoint}/{key}");
    }
}