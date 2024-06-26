using Blater.Models.User;
using Blater.SDK.Contracts.Common.Request;

namespace Blater.SDK.Interfaces;

public interface IBlaterAuthEmailRepositoryEndpoints
{
    Task<BlaterUser> FindByEmail(string email);
    Task<bool> ResetEmail(string email, ResetBlaterUserEmailRequest request);
    Task<BlaterUser> SetEmailConfirmed(BlaterUser user);
}