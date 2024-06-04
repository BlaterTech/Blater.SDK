using Blater.SDK.Contracts.Base;

namespace Blater.SDK.Contracts.Authentication.Response;

public class AuthResponse : BaseEndpointResponse
{
    public string? Jwt { get; set; }
}