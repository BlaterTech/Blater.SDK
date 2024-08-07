﻿using Blater.Exceptions;
using Blater.Models.User;

namespace Blater.SDK.Implementations.REST.BlaterAuthentication.Repositories;

public class BlaterAuthTwoFactorRepositoryEndPoints(IBlaterAuthTwoFactorStore storeEndPoints) : IBlaterAuthTwoFactorRepository
{
    public async Task<BlaterUser> EnableTwoFactor(BlaterUser user, string id, string secret)
    {
        var result = await storeEndPoints.EnableTwoFactor(user, id, secret);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error while enabling two factor");
        }

        return response;
    }

    public async Task<BlaterUser> DisableTwoFactor(BlaterUser user, string code)
    {
        var result = await storeEndPoints.DisableTwoFactor(user, code);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error while disabling two factor");
        }

        return response;
    }

    public async Task<bool> VerifyOtpCode(string code)
    {
        var result = await storeEndPoints.VerifyOtpCode(code);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }
}