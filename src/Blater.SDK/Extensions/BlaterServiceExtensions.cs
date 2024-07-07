using System.Diagnostics.CodeAnalysis;
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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Blater.SDK.Extensions;

public static class BlaterServiceExtensions
{
    [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract")]
    //TODO: Properly handle Environment variables
    public static void AddBlaterServices(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        
        if (configuration == null)
        {
            throw new Exception("Configuration is null");
        }

        var blaterSection = configuration.GetSection("Blater");
        
        //If null use the default configuration
        if (blaterSection == null)
        {
            BlaterHttpClient.Schema = "Bearer";
            services.AddHttpClient<BlaterHttpClient>(client =>
            {
                client.BaseAddress = new Uri("https://api.blater.tech");
            });
        }
        else
        {
            var schema = blaterSection.GetValue<string>("Schema", "Bearer");
            BlaterHttpClient.Schema = schema;
            
            var token = blaterSection.GetValue<string>("Token");
            BlaterHttpClient.Token = token;
            
            var baseUrl = blaterSection.GetValue<string>("BaseUrl", "https://api.blater.tech");
            services.AddHttpClient<BlaterHttpClient>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });
        }
        
        services.AddBlaterDatabase();
        services.AddBlaterManagement();
        services.AddBlaterKeyValue();
        services.AddBlaterAuthStores();
        services.AddBlaterAuthRepositories();
    }

    private static void AddBlaterDatabase(this IServiceCollection services)
    {
        //Store
        services.AddScoped<IBlaterDatabaseStore, BlaterDatabaseRest>();
        services.AddScoped(typeof(IBlaterDatabaseStoreT<>), typeof(BlaterDatabaseTRest<>));
        //Repository
        services.AddScoped(typeof(IBlaterDatabaseRepository<>), typeof(BlaterDatabaseRepositoryRest<>));
    }

    private static void AddBlaterManagement(this IServiceCollection services)
    {
        services.AddScoped<IBlaterManagementStoreEndpoints, BlaterManagementStoreEndpoints>();

        services.AddScoped<IBlaterManagementRepositoryEndpoints, BlaterManagementRepositoryEndpoints>();
    }

    private static void AddBlaterKeyValue(this IServiceCollection services)
    {
        services.AddScoped<IBlaterKeyValueStore, BlaterKeyValueStoreRest>();

        services.AddScoped<IBlaterKeyValueRepository, BlaterKeyValueRepositoryRest>();
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