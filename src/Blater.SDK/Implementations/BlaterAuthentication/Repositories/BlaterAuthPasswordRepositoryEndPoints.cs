using Blater.Exceptions;
using Blater.Interfaces.BlaterAuthentication.Stores;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthPasswordRepositoryEndPoints(BlaterAuthPasswordRepositoryEndPoints store) : IBlaterAuthPasswordStore
{
    public async Task<BlaterResult<bool>> ResetPassword(string email, string oldPassword, string newPassword)
    {
        var result = await store.ResetPassword(email, oldPassword, newPassword);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }
}