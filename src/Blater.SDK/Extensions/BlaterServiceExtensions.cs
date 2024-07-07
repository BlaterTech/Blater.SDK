using System.Net.Http.Headers;
using Blater.Models.User;
using Blater.SDK.Implementations;
using Blater.SDK.Interfaces.BlaterAuth;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Blater.SDK.Extensions;

public static class BlaterServiceExtensions
{
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
        if (blaterSection.Value == null)
        {
            services.AddSingleton<BlaterAuthState>();
            services.AddHttpClient<BlaterHttpClient>((sp, client) =>
            {
                client.BaseAddress = new Uri("https://api.blater.tech");
                //Add the token from BlaterAuthState
                var authState = sp.GetRequiredService<BlaterAuthState>();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authState.JwtToken);
            });
        }
        else
        {
            var token = blaterSection.GetValue<string>("Token");
            
            services.AddSingleton(new BlaterAuthState
            {
                JwtToken = token ?? string.Empty
            });

            var baseUrl = blaterSection.GetValue<string>("BaseUrl", "https://api.blater.tech");
            services.AddHttpClient<BlaterHttpClient>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            });
        }

        services.AddScoped<IBlaterSDK, BlaterSDK>();
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