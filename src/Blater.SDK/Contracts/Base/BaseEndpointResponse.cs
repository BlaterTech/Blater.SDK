using Blater.Constants;
using Blater.Resullts;

namespace Blater.SDK.Contracts.Base;

public class BaseEndpointResponse
{
    public BlaterCodes Status { get; set; }
    public string Message { get; set; } = null!;
    public List<BlaterError>? Errors { get; set; }
}