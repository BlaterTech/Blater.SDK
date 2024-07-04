using Blater.Results;

namespace Blater.SDK.Interfaces;

public interface IBlaterManagementStoreEndpoints
{
    Task<BlaterResult<string>> CreateDatabase(string databaseName);
    Task<BlaterResult> DeleteDatabase(string databaseName);
}