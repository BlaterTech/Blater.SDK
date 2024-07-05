using Blater.Exceptions;
using Blater.JsonUtilities;
using Blater.Results;
using Blater.SDK.Interfaces;

namespace Blater.SDK.Implementations.BlaterKeyValue.Stores;

public class BlaterKeyValueStoreEndPoints(BlaterHttpClient client) : IBlaterKeyValueStoreEndpoints
{
    private static string Endpoint => "v1/KeyValue";

    public async Task<BlaterResult<TValue>> Get<TValue>(string key)
    {
        var result = await client.Get<string>($"{Endpoint}/{key}");
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        if (!response.TryParseJson<TValue>(out var handleResponse))
        {
            return BlaterErrors.NotFound;
        }

        if (handleResponse != null)
        {
            return handleResponse;
        }

        return BlaterErrors.NotFound;
    }

    public Task<BlaterResult<string>> Get(string key)
    {
        return client.GetString($"{Endpoint}/{key}");
    }

    public Task<BlaterResult<IReadOnlyList<string>>> Get()
    {
        return client.Get<IReadOnlyList<string>>($"{Endpoint}");
    }

    public Task<BlaterResult<bool>> Set<TValue>(string key, TValue value)
    {
        var json = value.ToJson();
        if (string.IsNullOrWhiteSpace(json))
        {
            throw new BlaterException("Value is nullable");
        }

        return client.Post<bool>($"{Endpoint}/{key}", json);
    }

    public Task<BlaterResult<bool>> Set(string key, object value)
    {
        var json = value.ToJson();
        if (string.IsNullOrWhiteSpace(json))
        {
            throw new BlaterException("Value is nullable");
        }

        return client.Post<bool>($"{Endpoint}/{key}", json);
    }

    public Task<BlaterResult<bool>> Remove(string key)
    {
        return client.Delete<bool>($"{Endpoint}/{key}");
    }
}