using Blater.Exceptions;
using Blater.Interfaces.BlaterAuthentication.Repositories;
using Blater.Models.User;
using Blater.SDK.Contracts.Authentication.Request;
using Blater.SDK.Contracts.Common.Request;
using Blater.SDK.Implementations.BlaterAuthentication.Stores;
using IBlaterAuthLoginRepository = Blater.SDK.Interfaces.IBlaterAuthLoginRepository;

namespace Blater.SDK.Implementations.BlaterAuthentication.Repositories;

public class BlaterAuthLoginRepositoryEndPoints(BlaterAuthLoginStoreEndPoints storeEndPoints) : IBlaterAuthLoginRepository
{
    public async Task<string> LoginLocal(AuthRequest request)
    {
        var result = await storeEndPoints.LoginLocal(request);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }

    public async Task<BlaterUser> Register(RegisterBlaterUserRequest request)
    {
        var result = await storeEndPoints.Register(request);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }

    public async Task<BlaterUser> AddLogin(BlaterUser user, BlaterLoginInfo login)
    {
        var result = await storeEndPoints.AddLogin(user, login);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        if (response == null)
        {
            throw new BlaterException("Error while adding login");
        }
        
        return response;
    }
    
    public async Task<BlaterUser> RemoveLogin(BlaterUser user, string loginProvider, string providerKey)
    {
        var result = await storeEndPoints.RemoveLogin(user, loginProvider, providerKey);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        if (response == null)
        {
            throw new BlaterException("Error while removing login");
        }
        
        return response;
    }
    
    public async Task<IReadOnlyList<BlaterLoginInfo>> GetLogins(BlaterId id)
    {
        var result = await storeEndPoints.GetLogins(id);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        if (response == null)
        {
            throw new BlaterException("Error while getting logins");
        }
        
        return response;
    }
    
    public async Task<BlaterUser> FindByLogin(string loginProvider, string providerKey)
    {
        var result = await storeEndPoints.FindByLogin(loginProvider, providerKey);
        
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        if (response == null)
        {
            throw new BlaterException("Error while finding user by login");
        }
        
        return response;
    }
}