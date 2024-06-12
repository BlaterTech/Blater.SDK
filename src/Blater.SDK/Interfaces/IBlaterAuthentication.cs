using Blater.Resullts;
using Blater.SDK.Contracts.Authentication.Request;
using Blater.SDK.Contracts.Common.Request;

namespace Blater.SDK.Interfaces;

public interface IBlaterAuthentication
{
    Task<BlaterResult<bool>> ConfirmEmail(string email);
    Task<BlaterResult<bool>> DeleteEmail(string email, DeleteBlaterUserRequest request);
    
    
    Task<BlaterResult<string>> Login(AuthRequest request);
    Task LoginProvider(string provider);
    Task<BlaterResult<string>> SigninProvider(string provider);
    
    Task<BlaterResult<bool>> Register(RegisterBlaterUserRequest request);
    
    Task<BlaterResult<bool>> ResetEmail(string email, ResetBlaterUserEmailRequest request);
    Task<BlaterResult<bool>> ResetPassword(string email, ResetBlaterUserPasswordRequest request);
    
    Task<BlaterResult<bool>> TwoFactor(string email, bool enabled);
}