using Blater.Results;

namespace Blater.SDK.Implementations.REST.BlaterManagement.Stores;

public class BlaterManagementStoreEndpoints(BlaterHttpClient client) : IBlaterManagementStoreEndpoints
{
    private static string Endpoint => "v1/Management";

    public Task<BlaterResult<string>> CreateDatabase(string databaseName)
    {
        return client.PostString($"{Endpoint}/{databaseName}");
    }

    public Task<BlaterResult> DeleteDatabase(string databaseName)
    {
        return client.Delete($"{Endpoint}/{databaseName}");
    }
}