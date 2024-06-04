using Blater.Resullts;

namespace Blater.SDK.Contracts.Base;

public class BaseEndpointResponse
{
    public List<BlaterError>? Errors { get; set; }
}