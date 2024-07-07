namespace Blater.SDK.Interfaces.BlaterAuth;

//TODO this interface is not needed
public interface IBlaterManagementRepositoryEndpoints
{
    Task<string> CreateDatabase(string databaseName);
    Task<bool> DeleteDatabase(string databaseName);
}