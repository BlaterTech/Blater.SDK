namespace Blater.SDK.Interfaces;

public interface IBlaterSDK
{
    Task Login(string email, string password);
    Task Login(string token);
}