using Blater.Exceptions;
using Blater.SDK.Interfaces;

namespace Blater.SDK.Implementations.BlaterManagement.Repositories;

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

        return response;
    }

    public async Task<bool> DeleteDatabase(string databaseName)
    {
        var result = await storeEndPoints.DeleteDatabase(databaseName);
        return result.Success;
    }
}