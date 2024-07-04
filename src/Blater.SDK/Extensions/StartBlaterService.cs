using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Blater.SDK.Extensions;

internal class StartBlaterService(ILogger<StartBlaterService> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogDebug("Starting blater WS connection");
        await Task.Delay(1, stoppingToken);
        /*await BlaterServicesExtensions.HubConnection.StartAsync(stoppingToken).ConfigureAwait(false);

        BlaterServicesExtensions.HubConnection.Closed += exception =>
        {
            logger.LogError(exception, "Connection closed");
            return Task.CompletedTask;
        };

        BlaterServicesExtensions.HubConnection.Reconnected += connectionId =>
        {
            logger.LogInformation("Reconnected");
            return Task.CompletedTask;
        };

        BlaterServicesExtensions.HubConnection.Reconnecting += exception =>
        {
            logger.LogWarning(exception, "Reconnecting");
            return Task.CompletedTask;
        };*/
    }
}