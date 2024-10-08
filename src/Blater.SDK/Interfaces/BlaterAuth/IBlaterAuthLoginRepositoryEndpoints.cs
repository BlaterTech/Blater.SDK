﻿using Blater.Models.User;
using Blater.SDK.Contracts.Authentication.Request;
using Blater.SDK.Contracts.Common.Request;

namespace Blater.SDK.Interfaces.BlaterAuth;

//TODO this interface is not needed
public interface IBlaterAuthLoginRepositoryEndpoints
{
    Task<string> LoginLocal(AuthRequest request);
    Task<BlaterUser> Register(RegisterBlaterUserRequest request);

    Task<BlaterUser> AddLogin(BlaterUser user, BlaterLoginInfo login);

    Task<BlaterUser> RemoveLogin(BlaterUser user, string loginProvider, string providerKey);

    Task<IReadOnlyList<BlaterLoginInfo>> GetLogins(Ulid id);

    Task<BlaterUser> FindByLogin(string loginProvider, string providerKey);
}