namespace Blater.SDK.Interfaces;

public interface IBlaterManagementRepositoryEndpoints
{
    Task<string> CreateDatabase(string databaseName);
    Task<bool> DeleteDatabase(string databaseName);
}