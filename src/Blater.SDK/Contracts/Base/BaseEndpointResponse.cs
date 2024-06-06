using Blater.Constants;
using Blater.Resullts;

namespace Blater.SDK.Contracts.Base;

public class BaseEndpointResponse : BlaterResult
{
    public BlaterCodes Status { get; set; }
    public string Message { get; set; } = null!;
}