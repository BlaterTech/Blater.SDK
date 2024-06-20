using Blater.Interfaces;
using Blater.Query.Models;
using Blater.Results;

namespace Blater.SDK.Implementations;

public class BlaterDatabaseStoreTEndPoints(BlaterDatabaseStoreEndPoints storeEndPoints) : IBlaterDatabaseStoreT
{
    public string? Partition { get; set; }

    public Task<BlaterResult<string>> Get(BlaterId id)
    {
        return client.Get<string>($"{endpoint}/get/{id}");
    }

    public Task<BlaterResult<string>> QueryOne(BlaterQuery query)
    {
        if (query == null)
        {
            return Task.FromResult(new BlaterResult<string>(new BlaterError("Query Error")));
        }

        return client.Post<string>($"{endpoint}/queryOne", query);#1#
        throw new NotImplementedException();
    }

    public Task<BlaterResult<string>> QueryOne(string partition, BlaterQuery query)
    {
        if (query == null)
        {
            return Task.FromResult(new BlaterResult<string>(new BlaterError("Query Error")));
        }

        return client.Post<string>($"{endpoint}/{partition}/queryOne", query);
    }

    public Task<BlaterResult<IReadOnlyList<string>>> Query(BlaterQuery query)
    {
        if (query == null)
        {
            return Task.FromResult(new BlaterResult<string>(new BlaterError("Query Error")));
        }

        return client.Post<string>($"{endpoint}/query", query);

        throw new NotImplementedException();
    }

    public Task<BlaterResult<IReadOnlyList<string>>> Query(string partition, BlaterQuery query)
    {
        if (query == null)
        {
            return Task.FromResult(new BlaterResult<IReadOnlyList<string>>(new BlaterError("Query Error")));
        }

        return client.Post<IReadOnlyList<string>>($"{endpoint}/{partition}/query", query);
    }

    public IAsyncEnumerable<BlaterResult<string>> GetChanges()
    {
        return client.Get<string>($"{endpoint}/{partition}/changes");
    }

    public IAsyncEnumerable<BlaterResult<string>> GetChangesQuery(BlaterQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<BlaterResult<BlaterId>> Upsert(BlaterId id, string json)
    {
        throw new NotImplementedException();
    }

    public Task<BlaterResult<BlaterId>> Update(BlaterId id, string json)
    {
        throw new NotImplementedException();
    }

    public Task<BlaterResult<BlaterId>> Insert(BlaterId id, string json)
    {
        throw new NotImplementedException();
    }

    public Task<BlaterResult<bool>> Delete(BlaterId id)
    {
        throw new NotImplementedException();
    }

    public Task<BlaterResult<int>> Delete(List<BlaterId> ids)
    {
        throw new NotImplementedException();
    }

    public Task<BlaterResult<int>> Delete(BlaterQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<BlaterResult<int>> Count()
    {
        throw new NotImplementedException();
    }

    public Task<BlaterResult<int>> Count(string partition)
    {
        throw new NotImplementedException();
    }

    public Task<BlaterResult<int>> Count(string partition, BlaterQuery query)
    {
        throw new NotImplementedException();
    }
}