﻿using Blater.Exceptions;
using Blater.Models.User;

namespace Blater.SDK.Implementations.REST.BlaterAuthentication.Repositories;

public class BlaterAuthLockoutRepositoryEndPoints(IBlaterAuthLockoutStore storeEndPoints) : IBlaterAuthLockoutRepository
{
    public async Task<BlaterUser> SetLockoutEndDate(BlaterUser user, DateTimeOffset? lockoutEnd)
    {
        var result = await storeEndPoints.SetLockoutEndDate(user, lockoutEnd);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error occurred while setting lockout end date.");
        }

        return response;
    }

    public async Task<int> IncrementAccessFailedCount(BlaterUser user)
    {
        var result = await storeEndPoints.IncrementAccessFailedCount(user);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }

    public async Task<BlaterUser> ResetAccessFailedCount(BlaterUser user)
    {
        var result = await storeEndPoints.ResetAccessFailedCount(user);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error occurred while resetting access failed count.");
        }

        return response;
    }

    public async Task<BlaterUser> SetLockoutEnabled(BlaterUser user, bool enabled)
    {
        var result = await storeEndPoints.SetLockoutEnabled(user, enabled);

        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException("Error occurred while setting lockout enabled.");
        }

        return response;
    }
}