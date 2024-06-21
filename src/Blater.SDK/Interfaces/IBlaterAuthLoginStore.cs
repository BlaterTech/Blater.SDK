using Blater.Models.User;
using Blater.Results;
using Blater.SDK.Contracts.Authentication.Request;
using Blater.SDK.Contracts.Common.Request;

namespace Blater.SDK.Interfaces;

public interface IBlaterAuthLoginStore
{
    Task<BlaterResult<string>> LoginLocal(AuthRequest request);
    Task<BlaterResult<BlaterUser>> Register(RegisterBlaterUserRequest request);
    
    Task<BlaterResult<BlaterUser>> AddLogin(BlaterUser user, BlaterLoginInfo login);
    
    Task<BlaterResult<BlaterUser>> RemoveLogin(BlaterUser user, string loginProvider, string providerKey);
    
    Task<BlaterResult<IReadOnlyList<BlaterLoginInfo>>> GetLogins(BlaterId id);
    
    Task<BlaterResult<BlaterUser>> FindByLogin(string loginProvider, string providerKey);
}