/*using System.Runtime.CompilerServices;
using Blater.Exceptions;
using Blater.Models.Database;
using Blater.Results;

namespace Blater.SDK.Implementations.REST.BlaterDatabase.Stores;

public class BlaterDatabaseRest(BlaterHttpClient client) : IBlaterDatabaseStore
{
    private static string Endpoint => "/v1/Database";

    public Task<BlaterResult<string>> Get(Ulid id)
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

    public async Task<BlaterResult<Ulid>> Upsert(Ulid id, string json)
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

        var Ulid = response.ToUlid();
        return Ulid;
    }

    public async Task<BlaterResult<Ulid>> Update(Ulid id, string json)
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

        var Ulid = response.ToUlid();
        return Ulid;
    }

    public async Task<BlaterResult<Ulid>> Insert(Ulid id, string json)
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

        var Ulid = response.ToUlid();
        return Ulid;
    }

    public Task<BlaterResult<bool>> Delete(Ulid id)
    {
        return client.Delete<bool>($"{Endpoint}/delete/{id}");
    }

    public Task<BlaterResult<int>> Delete(List<Ulid> ids)
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
}*/