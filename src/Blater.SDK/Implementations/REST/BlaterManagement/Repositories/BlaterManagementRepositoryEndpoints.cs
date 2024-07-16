using Blater.Exceptions;
using Blater.SDK.Interfaces.BlaterAuth;

namespace Blater.SDK.Implementations.REST.BlaterManagement.Repositories;

public class BlaterManagementRepositoryEndpoints(IBlaterManagementStoreEndpoints storeEndPoints)
    : IBlaterManagementRepositoryEndpoints
{
    public async Task<string> CreateDatabase(string databaseName)
    {
        var result = await storeEndPoints.CreateDatabase(databaseName);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response ?? string.Empty;
    }

    public async Task<bool> DeleteDatabase(string databaseName)
    {
        var result = await storeEndPoints.DeleteDatabase(databaseName);
        return result.Success;
    }
}