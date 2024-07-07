using System.Linq.Expressions;
using Blater.Exceptions;
using Blater.Interfaces;
using Blater.JsonUtilities;
using Blater.Models.Bases;
using Blater.Query.Extensions;
using Blater.Query.Models;
using Blater.Results;
using Blater.SDK.Interfaces;

namespace Blater.SDK.Implementations.BlaterDatabase.Stores;

public class BlaterDatabaseTEndPoints<T>(IBlaterDatabaseEndpoints endPoints)
    : IBlaterDatabaseStoreTEndpoints<T>
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

        var result = await endPoints.Get(id);
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
        var result = await endPoints.QueryOne(Partition, query);
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
        var result = await endPoints.QueryOne(Partition, blaterQuery);
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
        var result = await endPoints.Query(Partition, query);
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
        var result = await endPoints.Query(Partition, blaterQuery);
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
    
    public async Task<BlaterResult<T>> Upsert(T obj)
    {
        if (obj.Id == BlaterId.Empty || obj.Id == null!)
        {
            obj.Id = BlaterId.New(Partition);
        }

        var result = await endPoints.Upsert(obj.Id, obj.ToJson()!);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        obj.Id = response;

        return obj;
    }

    public Task<BlaterResult<T>> Update(T obj)
    {
        return Update(obj.Id, obj);
    }

    public async Task<BlaterResult<T>> Update(BlaterId id, T obj)
    {
        ValidatePartition(id);

        var result = await endPoints.Update(id, obj.ToJson()!);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        obj.Id = response;

        return obj;
    }

    public async Task<BlaterResult<T>> Insert(BlaterId id, T obj)
    {
        if (obj.Id != BlaterId.Empty)
        {
            return BlaterErrors.InvalidOperation("Id must be empty");
        }

        obj.Id = BlaterId.New(Partition);

        var json = obj.ToJson();

        if (json == null)
        {
            return BlaterErrors.JsonSerializationError("Error in serialize json");
        }

        var result = await endPoints.Insert(obj.Id, json);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        obj.Id = response;

        return obj;
    }

    public Task<BlaterResult<T>> Insert(T obj)
    {
        obj.Id = BlaterId.New(Partition);
        return Insert(obj.Id, obj);
    }

    #endregion

    #region Changes

    public async IAsyncEnumerable<BlaterResult<T>> GetChangesQuery(BlaterQuery query)
    {
        var result = endPoints.WatchChangesQuery(Partition, query, CancellationToken.None);

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

        var result = await endPoints.Delete(id);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }
        
        return response;
    }

    public async Task<BlaterResult<int>> Delete(List<BlaterId> ids)
    {
        ids.ForEach(ValidatePartition);

        var result = await endPoints.Delete(ids);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }
        
        return response;
    }

    public async Task<BlaterResult<int>> Delete(BlaterQuery query)
    {
        var result = await endPoints.Delete(query);
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
        var result = await endPoints.Count(Partition);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }
        
        return response;
    }

    #endregion
}