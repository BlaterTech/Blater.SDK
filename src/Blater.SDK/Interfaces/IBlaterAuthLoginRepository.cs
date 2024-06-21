using Blater.Models.User;
using Blater.Results;
using Blater.SDK.Contracts.Authentication.Request;
using Blater.SDK.Contracts.Common.Request;

namespace Blater.SDK.Interfaces;

public interface IBlaterAuthLoginRepository
{
    Task<string> LoginLocal(AuthRequest request);
    Task<BlaterUser> Register(RegisterBlaterUserRequest request);
    
    Task<BlaterUser> AddLogin(BlaterUser user, BlaterLoginInfo login);
    
    Task<BlaterUser> RemoveLogin(BlaterUser user, string loginProvider, string providerKey);
    
    Task<IReadOnlyList<BlaterLoginInfo>> GetLogins(BlaterId id);
    
    Task<BlaterUser> FindByLogin(string loginProvider, string providerKey);
}