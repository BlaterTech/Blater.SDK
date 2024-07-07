using Blater.Exceptions;

namespace Blater.SDK.Implementations.REST.BlaterKeyValue.Repositories;

public class BlaterKeyValueRepositoryRest(IBlaterKeyValueStore keyValueStore) 
    : IBlaterKeyValueRepository
{
    private static void ValidateKey(string key)
    {
        var parts = key.Split(':');

        if (parts.Length != 2)
        {
            throw new FormatException("The value is not in the correct format");
        }
    }
    
    public async Task<TValue> Get<TValue>(string key)
    {
        ValidateKey(key);
        
        var result = await keyValueStore.Get<TValue>(key);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }
    
    public async Task<string> Get(string key)
    {
        ValidateKey(key);
        
        var result = await keyValueStore.Get(key);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }
    
    public async Task<IReadOnlyList<string>> Get()
    {
        var result = await keyValueStore.Get();
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }
    
    public async Task<bool> Set<TValue>(string key, TValue value)
    {
        ValidateKey(key);
        
        var result = await keyValueStore.Set(key, value);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async Task<bool> Set(string key, object value)
    {
        ValidateKey(key);
        
        var result = await keyValueStore.Set(key, value);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async Task<bool> Remove(string key)
    {
        ValidateKey(key);
        
        var result = await keyValueStore.Remove(key);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
}