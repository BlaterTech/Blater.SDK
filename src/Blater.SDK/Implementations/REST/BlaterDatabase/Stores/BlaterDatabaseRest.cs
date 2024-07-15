using System.Runtime.CompilerServices;
using Blater.Exceptions;
using Blater.Interfaces;
using Blater.Query.Models;
using Blater.Results;

namespace Blater.SDK.Implementations.REST.BlaterDatabase.Stores;

public class BlaterDatabaseRest(BlaterHttpClient client) : IBlaterDatabaseStore
{
    private static string Endpoint => "/v1/Database";

    public Task<BlaterResult<string>> Get(BlaterId id)
    {
        return client.Get<string>($"{Endpoint}/{id}");
    }

    public Task<BlaterResult<string>> QueryOne(string partition, BlaterQuery query)
    {
        return client.Post<string>($"{Endpoint}/{partition}/queryOne", query);
    }

    public Task<BlaterResult<IReadOnlyList<string>>> Query(string partition, BlaterQuery query)
    {
        return client.Post<IReadOnlyList<string>>($"{Endpoint}/{partition}/query", query);
    }

    public async IAsyncEnumerable<BlaterResult<string>> WatchChangesQuery(string partition, BlaterQuery query, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var result = client.PostStream<string>($"{Endpoint}/{partition}/changes/query", query, cancellationToken);

        await foreach (var item in result)
        {
            if (item.HandleErrors(out var errors, out var response))
            {
                throw new BlaterException(errors);
            }

            yield return response ?? string.Empty;
        }
    }

    public async Task<BlaterResult<BlaterId>> Upsert(BlaterId id, string json)
    {
        var result = await client.Put<string>($"{Endpoint}/upsert/{id}", json);

        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        if (string.IsNullOrWhiteSpace(response))
        {
            return BlaterErrors.DatabaseError;
        }

        var blaterId = response.ToBlaterId();
        return blaterId;
    }

    public async Task<BlaterResult<BlaterId>> Update(BlaterId id, string json)
    {
        var result = await client.Put<string>($"{Endpoint}/update/{id}", json);

        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }
        
        if (string.IsNullOrWhiteSpace(response))
        {
            return BlaterErrors.DatabaseError;
        }

        var blaterId = response.ToBlaterId();
        return blaterId;
    }

    public async Task<BlaterResult<BlaterId>> Insert(BlaterId id, string json)
    {
        var result = await client.Post<string>($"{Endpoint}/insert/{id}", json);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }
        
        if (string.IsNullOrWhiteSpace(response))
        {
            return BlaterErrors.DatabaseError;
        }

        var blaterId = response.ToBlaterId();
        return blaterId;
    }

    public Task<BlaterResult<bool>> Delete(BlaterId id)
    {
        return client.Delete<bool>($"{Endpoint}/delete/{id}");
    }

    public Task<BlaterResult<int>> Delete(List<BlaterId> ids)
    {
        var stringIds = ids.Select(x => x.ToString());
        return client.Post<int>($"{Endpoint}/delete", stringIds);
    }

    public Task<BlaterResult<int>> Delete(BlaterQuery query)
    {
        return client.Post<int>($"{Endpoint}/delete/query", query);
    }

    public Task<BlaterResult<int>> Count(string partition)
    {
        return client.Get<int>($"{Endpoint}/{partition}/count");
    }

    public Task<BlaterResult<int>> Count(string partition, BlaterQuery query)
    {
        return client.Post<int>($"{Endpoint}/{partition}/count", query);
    }
}