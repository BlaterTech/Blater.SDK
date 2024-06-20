using Blater.Interfaces;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterKeyValue.Stores;

public class BlaterKeyValueStoreEndPoints(BlaterHttpClient client) : IBlaterKeyValueStore
{
    private static string Endpoint => "/v1/KeyValue";
    
    public Task<BlaterResult<TValue>> Get<TValue>(string key)
    {
        return client.Get<TValue>($"{Endpoint}/{key}");
    }
    
    public Task<BlaterResult<string>> Get(string key)
    {
        return client.Get<string>($"{Endpoint}/{key}");
    }
    
    public Task<BlaterResult<IReadOnlyList<string>>> Get()
    {
        return client.Get<IReadOnlyList<string>>($"{Endpoint}");
    }
    
    public Task<BlaterResult<bool>> Set<TValue>(string key, TValue value)
    {
        if (value != null)
        {
            return client.Post<bool>($"{Endpoint}/{key}", value);
        }
        
        return new Task<BlaterResult<bool>>(() => new BlaterResult<bool>(false));
    }
    
    public Task<BlaterResult<bool>> Set(string key, object value)
    {
        return client.Post<bool>($"{Endpoint}/{key}", value);
    }
    
    public Task<BlaterResult<bool>> Remove(string key)
    {
        return client.Delete<bool>($"{Endpoint}/{key}");
    }
}