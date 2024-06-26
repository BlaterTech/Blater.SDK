using System.Linq.Expressions;
using Blater.Exceptions;
using Blater.Interfaces;
using Blater.JsonUtilities;
using Blater.Query.Extensions;
using Blater.Query.Models;
using Blater.Results;

namespace Blater.SDK.Implementations.BlaterDatabase.Stores;

public class BlaterDatabaseStoreTEndPoints<T>(IBlaterDatabaseStore storeEndPoints)
    : IBlaterDatabaseStoreT<T>
    where T : BaseDataModel
{
    public string Partition => typeof(T).FullName?.SanitizeString() ?? string.Empty;

    private void ValidatePartition(BlaterId id)
    {
        if (id.Partition != Partition)
        {
            throw new BlaterException("Could not get the type name of the entity");
        }
    }

    #region FindOne

    public async Task<BlaterResult<T>> FindOne(BlaterId id)
    {
        ValidatePartition(id);

        var result = await storeEndPoints.Get(id);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        if (!response.TryParseJson<T>(out var value))
        {
            return BlaterErrors.JsonSerializationError("Error in deserialize json");
        }

        if (value == null)
        {
            return BlaterErrors.NotFound;
        }
        
        return value;
    }

    public async Task<BlaterResult<T>> FindOne(BlaterQuery query)
    {
        var result = await storeEndPoints.QueryOne(Partition, query);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        var model = response.FromJson<T>();

        if (model == null)
        {
            return BlaterErrors.NotFound;
        }
        
        return model;
    }

    public async Task<BlaterResult<T>> FindOne(Expression<Func<T, bool>> predicate)
    {
        var blaterQuery = predicate.ExpressionToBlaterQuery();
        var result = await storeEndPoints.QueryOne(Partition, blaterQuery);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        var model = response.FromJson<T>();

        if (model == null)
        {
            return BlaterErrors.NotFound;
        }
        
        return model;
    }

    #endregion

    #region FindMany

    public async Task<BlaterResult<IReadOnlyList<T>>> FindMany(BlaterQuery query)
    {
        var result = await storeEndPoints.Query(Partition, query);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        var models = response.Select(x => x.FromJson<T>()).ToList();

        if (models.Count == 0)
        {
            return BlaterErrors.NotFound;
        }
        
        return models.AsReadOnly()!;
    }

    public async Task<BlaterResult<IReadOnlyList<T>>> FindMany(Expression<Func<T, bool>> predicate)
    {
        var blaterQuery = predicate.ExpressionToBlaterQuery();
        var result = await storeEndPoints.Query(Partition, blaterQuery);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        var models = response.Select(x => x.FromJson<T>()).ToList();

        if (models.Count == 0)
        {
            return BlaterErrors.NotFound;
        }
        
        return models.AsReadOnly()!;
    }

    #endregion

    #region Upsert/Update/Insert

    public async Task<BlaterResult<T>> Upsert(BlaterId id, T obj)
    {
        ValidatePartition(id);
        
        var result = await storeEndPoints.Upsert(id, obj.ToJson()!);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        obj.Id = response;

        return obj;
    }

    public async Task<BlaterResult<T>> Update(BlaterId id, T obj)
    {
        ValidatePartition(id);
        
        var result = await storeEndPoints.Update(id, obj.ToJson()!);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        obj.Id = response;

        return obj;
    }

    public async Task<BlaterResult<T>> Insert(BlaterId id, T obj)
    {
        ValidatePartition(id);
        
        var result = await storeEndPoints.Insert(id, obj.ToJson()!);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        obj.Id = response;

        return obj;
    }

    #endregion

    #region Changes

    public async IAsyncEnumerable<BlaterResult<T>> GetChangesQuery(BlaterQuery query)
    {
        var result = storeEndPoints.WatchChangesQuery(Partition, query);

        await foreach (var item in result)
        {
            if (item.HandleErrors(out var errors, out var response))
            {
                yield return errors;
            }

            var model = response.FromJson<T>();

            if (model == null)
            {
                yield return BlaterErrors.JsonSerializationError(response);
            }
            
            yield return model!;
        }
    }

    #endregion

    #region Delete

    public async Task<BlaterResult<bool>> Delete(BlaterId id)
    {
        ValidatePartition(id);

        var result = await storeEndPoints.Delete(id);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }
        
        return response;
    }

    public async Task<BlaterResult<int>> Delete(List<BlaterId> ids)
    {
        ids.ForEach(ValidatePartition);

        var result = await storeEndPoints.Delete(ids);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }
        
        return response;
    }

    public async Task<BlaterResult<int>> Delete(BlaterQuery query)
    {
        var result = await storeEndPoints.Delete(query);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }
        
        return response;
    }

    #endregion

    #region Count

    public async Task<BlaterResult<int>> Count()
    {
        var result = await storeEndPoints.Count(Partition);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }
        
        return response;
    }

    #endregion
}