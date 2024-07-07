using Blater.Models.User;
using Blater.Results;
using Blater.SDK.Contracts.Common.Request;

namespace Blater.SDK.Interfaces.BlaterAuth;

//TODO this interface is not needed
public interface IBlaterAuthEmailStoreEndpoints
{
    Task<BlaterResult<BlaterUser>> FindByEmail(string email);
    Task<BlaterResult<bool>> ResetEmail(string email, ResetBlaterUserEmailRequest request);
    Task<BlaterResult<BlaterUser>> SetEmailConfirmed(BlaterUser user);
}