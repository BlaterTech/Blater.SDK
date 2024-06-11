using Blater.Resullts;

namespace Blater.SDK.Contracts.Base;

public class BaseEndpointResponse : BlaterResult
{
    public string Message { get; set; } = null!;
}