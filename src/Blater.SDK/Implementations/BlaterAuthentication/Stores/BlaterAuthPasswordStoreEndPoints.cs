using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Results;
using Blater.SDK.Contracts.Common.Request;

namespace Blater.SDK.Implementations.BlaterAuthentication.Stores;

public class BlaterAuthPasswordStoreEndPoints(BlaterHttpClient client) : IBlaterAuthPasswordStore
{
    private static string Endpoint => "/v1/Auth";

    public Task<BlaterResult<bool>> ResetPassword(string email, string oldPassword, string newPassword)
    {
        var request = new ResetBlaterUserPasswordRequest
        {
            NewPassword = newPassword,
            OldPassword = oldPassword
        };
        return client.Post<bool>($"{Endpoint}/resetPassword/{email}", request);
    }
}