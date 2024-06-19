using Blater.Interfaces;
using Blater.Query.Models;
using Blater.Results;

namespace Blater.SDK.Implementations;

public class BlaterDatabaseStoreEndPoints(BlaterHttpClient client) : IBlaterDatabaseStore
{
    public string? Partition { get; set; }
    private static string? Endpoint => "/v1/Database";
    
    public Task<BlaterResult<string>> Get(BlaterId id)
    {
        return client.Get<string>($"{Endpoint}/get/{id}");
    }
    
    public Task<BlaterResult<string>> QueryOne(BlaterQuery query)
    {
        /*return client.Post<string>($"{Endpoint}/queryOne", query);*/
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<string>> QueryOne(string partition, BlaterQuery query)
    {
        return client.Post<string>($"{Endpoint}/{partition}/queryOne", query);
    }
    
    public Task<BlaterResult<IReadOnlyList<string>>> Query(BlaterQuery query)
    {
        /*return client.Post<string>($"{Endpoint}/query", query);*/
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<IReadOnlyList<string>>> Query(string partition, BlaterQuery query)
    {
        return client.Post<IReadOnlyList<string>>($"{Endpoint}/{partition}/query", query);
    }
    
    public IAsyncEnumerable<BlaterResult<string>> GetChangesQuery(BlaterQuery query)
    {
        //return client.Get<string>($"{Endpoint}/{partition}/changes/query", query);
        throw new NotImplementedException();
    }
    
    public Task<BlaterResult<BlaterId>> Upsert(BlaterId id, string json)
    {
        return client.Put<BlaterId>($"{Endpoint}/upsert/{id}", json);
    }
    
    public Task<BlaterResult<BlaterId>> Update(BlaterId id, string json)
    {
        return client.Put<BlaterId>($"{Endpoint}/update/{id}", json);
    }
    
    public Task<BlaterResult<BlaterId>> Insert(BlaterId id, string json)
    {
        return client.Post<BlaterId>($"{Endpoint}/insert/{id}", json);
    }
    
    public Task<BlaterResult<bool>> Delete(BlaterId id)
    {
        return client.Delete<bool>($"{Endpoint}/delete/{id}");
    }
    
    public Task<BlaterResult<int>> Delete(List<BlaterId> ids)
    {
        return client.Post<int>($"{Endpoint}/delete", ids);
    }
    
    public Task<BlaterResult<int>> Delete(BlaterQuery query)
    {
        return client.Post<int>($"{Endpoint}/delete", query);
    }
    
    public Task<BlaterResult<int>> Count()
    {
        throw new NotImplementedException();
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