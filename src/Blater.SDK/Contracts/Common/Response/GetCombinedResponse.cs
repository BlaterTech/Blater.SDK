namespace Blater.SDK.Contracts.Common.Response;

public class GetCombinedResponse
{
    public TimeSpan DatabasePing { get; set; }
    public TimeSpan TotalPing { get; set; }
}