using Blater.Interfaces;
using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.SDK.Implementations.BlaterAuthentication.Repositories;
using Blater.SDK.Implementations.BlaterAuthentication.Stores;
using Blater.SDK.Implementations.BlaterDatabase.Stores;
using Blater.SDK.Implementations.BlaterKeyValue.Stores;
using Blater.SDK.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Blater.SDK.Extensions;

public static class BlaterServiceExtensions
{
    public static void AddBlaterServices(this IServiceCollection services)
    {
        services.AddHttpClient<BlaterHttpClient>((client) =>
        {
            client.BaseAddress = new Uri("http://localhost:5296");
        });

        services.AddScoped<IBlaterDatabaseStore, BlaterDatabaseStoreEndPoints>();
        services.AddScoped<IBlaterKeyValueStore, BlaterKeyValueStoreEndPoints>();
        services.AddScoped(typeof(IBlaterDatabaseStoreT<>), typeof(BlaterDatabaseStoreTEndPoints<>));
        
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