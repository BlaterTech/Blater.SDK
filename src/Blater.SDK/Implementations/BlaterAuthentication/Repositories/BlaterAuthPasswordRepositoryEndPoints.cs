using Blater.Exceptions;
using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Interfaces.BlaterAuthentication.Stores;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthPasswordRepositoryEndPoints(IBlaterAuthPasswordStore store) : IBlaterAuthPasswordRepository
{
    public async Task<bool> ResetPassword(string email, string oldPassword, string newPassword)
    {
        var result = await store.ResetPassword(email, oldPassword, newPassword);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }
}