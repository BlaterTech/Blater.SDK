using Blater.Interfaces;
using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.SDK.Implementations.BlaterAuthentication.Repositories;
using Blater.SDK.Implementations.BlaterAuthentication.Stores;
using Blater.SDK.Implementations.BlaterDatabase.Repositories;
using Blater.SDK.Implementations.BlaterDatabase.Stores;
using Blater.SDK.Implementations.BlaterKeyValue.Repositories;
using Blater.SDK.Implementations.BlaterKeyValue.Stores;
using Blater.SDK.Implementations.BlaterManagement.Repositories;
using Blater.SDK.Implementations.BlaterManagement.Stores;
using Blater.SDK.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Blater.SDK.Extensions;

public static class BlaterServiceExtensions
{
    public static void AddBlaterServices(this IServiceCollection services)
    {
        services.AddHttpClient<BlaterHttpClient>(client =>
        {
            BlaterHttpClient.Schema = "Bearer";
            client.BaseAddress = new Uri("https://api.blater.tech");
        });

        services.AddBlaterDatabase();
        services.AddBlaterManagement();
        services.AddBlaterKeyValue();
        services.AddBlaterAuthStores();
        services.AddBlaterAuthRepositories();
    }

    private static void AddBlaterDatabase(this IServiceCollection services)
    {
        services.AddScoped<IBlaterDatabaseEndpoints, BlaterDatabaseEndPoints>();
        services.AddScoped(typeof(IBlaterDatabaseStoreTEndpoints<>), typeof(BlaterDatabaseTEndPoints<>));

        services.AddScoped(typeof(IBlaterDatabaseRepository<>), typeof(BlaterDatabaseRepositoryEndPoints<>));
    }

    private static void AddBlaterManagement(this IServiceCollection services)
    {
        services.AddScoped<IBlaterManagementStoreEndpoints, BlaterManagementStoreEndpoints>();

        services.AddScoped<IBlaterManagementRepositoryEndpoints, BlaterManagementRepositoryEndpoints>();
    }

    private static void AddBlaterKeyValue(this IServiceCollection services)
    {
        services.AddScoped<IBlaterKeyValueStoreEndpoints, BlaterKeyValueStoreEndPoints>();

        services.AddScoped<IBlaterKeyValueRepository, BlaterKeyValueRepositoryEndPoints>();
    }

    private static void AddBlaterAuthStores(this IServiceCollection services)
    {
        services.AddScoped<IBlaterAuthEmailStoreEndpoints, BlaterAuthEmailStoreEndpoints>();
        services.AddScoped<IBlaterAuthLoginStoreEndpoints, BlaterAuthLoginStoreEndpoints>();
        services.AddScoped<IBlaterAuthLockoutStore, BlaterAuthLockoutStoreEndPoints>();
        services.AddScoped<IBlaterAuthTwoFactorStore, BlaterAuthTwoFactorStoreEndPoints>();
        services.AddScoped<IBlaterAuthPasswordStore, BlaterAuthPasswordStoreEndPoints>();
        services.AddScoped<IBlaterAuthPermissionRoleStore, BlaterAuthPermissionRoleStoreEndPoints>();
        services.AddScoped<IBlaterAuthPermissionStore, BlaterAuthPermissionStoreEndPoints>();
        services.AddScoped<IBlaterAuthRoleStore, BlaterAuthRoleStoreEndPoints>();
        services.AddScoped<IBlaterAuthUserRoleStore, BlaterAuthUserRoleStoreEndPoints>();
        services.AddScoped<IBlaterAuthUserPermissionStore, BlaterAuthUserPermissionStoreEndPoints>();
    }

    private static void AddBlaterAuthRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBlaterAuthEmailRepositoryEndpoints, BlaterAuthEmailRepositoryEndpoints>();
        services.AddScoped<IBlaterAuthLoginRepositoryEndpoints, BlaterAuthLoginRepositoryEndpoints>();
        services.AddScoped<IBlaterAuthLockoutRepository, BlaterAuthLockoutRepositoryEndPoints>();
        services.AddScoped<IBlaterAuthTwoFactorRepository, BlaterAuthTwoFactorRepositoryEndPoints>();
        services.AddScoped<IBlaterAuthPasswordRepository, BlaterAuthPasswordRepositoryEndPoints>();
        services.AddScoped<IBlaterAuthPermissionRoleRepository, BlaterAuthPermissionRoleRepositoryEndPoints>();
        services.AddScoped<IBlaterAuthPermissionRepository, BlaterAuthPermissionRepositoryEndPoints>();
        services.AddScoped<IBlaterAuthRoleRepository, BlaterAuthRoleRepositoryEndPoints>();
        services.AddScoped<IBlaterAuthUserRoleRepository, BlaterAuthUserRoleRepositoryEndPoints>();
        services.AddScoped<IBlaterAuthUserPermissionRepository, BlaterAuthUserPermissionsRepositoryEndPoints>();
    }
}