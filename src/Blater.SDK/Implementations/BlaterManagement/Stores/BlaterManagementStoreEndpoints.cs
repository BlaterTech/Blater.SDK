using Blater.Results;
using Blater.SDK.Interfaces;

namespace Blater.SDK.Implementations.BlaterManagement.Stores;

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