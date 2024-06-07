using Blater.Hubs;
using Blater.SignalR.SourceGenerator;
using Blater.Utilities;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blater.SDK.Extensions;

public static class BlaterServiceExtensions
{
    internal static HubConnection HubConnection = null!;
    
    public static void AddBlaterServices(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        
        var blaterSection = configuration.GetSection("Blater");
        //TODO Get TenantId, ClientSecret, ClientId, Region, and Environment from configuration
        //If ClientSecret is not provided, the user must authenticate manually
        
        HubConnection = new HubConnectionBuilder()
                       .WithUrl("http://localhost:5136/BlaterEndpoint", options => options.Headers.Add("TenantId", SequentialGuidGenerator.NewGuid().ToString()))
                       .WithStatefulReconnect()
                       .WithKeepAliveInterval(TimeSpan.FromSeconds(30))
                       .Build();
        
        services.AddHostedService<StartBlaterService>();
        
        var authHub = HubConnection.CreateHubProxy<IBlaterAuthHub>();
        
        
        
        
        //services.AddSingleton<IBlaterAuth>(blaterHub);
        
        //services.AddTransient(typeof(IBlaterDatabaseRepository<>), typeof(BlaterDatabaseRepository<>));
        //services.AddScoped<IBlaterQueue, BlaterQueue>();
        //services.AddScoped<IBlaterAuthEndpoint, BlaterAuthEndpoint>();
    }
}