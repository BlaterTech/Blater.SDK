using Blater.Constants;
using Blater.SDK.Contracts.Base;

namespace Blater.SDK.Contracts.Authentication.Response;

public class AuthResponse : BaseEndpointResponse
{
    public string? Jwt { get; set; }
    public string? Message { get; set; }
    public BlaterCodes Status { get; set; }
}