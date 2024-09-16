/*using System.Linq.Expressions;
using Blater.Exceptions;
using Blater.Models.Bases;
using Blater.Models.Database;
using Blater.Results;

namespace Blater.SDK.Implementations.REST.BlaterDatabase.Stores;

public class BlaterDatabaseTRest<T>(IBlaterDatabaseStore store)
    : IBlaterDatabaseStoreT<T>
    where T : BaseDataModel
{
    public string Partition => typeof(T).FullName?.SanitizeString() ?? string.Empty;

    private void ValidatePartition(Ulid id)
    {
        if (id.Partition != Partition)
        {
            throw new BlaterException("Could not get the type name of the entity");
        }
    }

    #region FindOne

    public async Task<BlaterResult<T>> FindOne(Ulid id)
    {
        ValidatePartition(id);

        var result = await store.Get(id);
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
        var result = await store.QueryOne(Partition, query);
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
        var result = await store.QueryOne(Partition, blaterQuery);
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
        var result = await store.Query(Partition, query);
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
        var result = await store.Query(Partition, blaterQuery);
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
        if (obj.Id == Ulid.Empty || obj.Id == null!)
        {
            obj.Id = Ulid.New(Partition);
        }

        var result = await store.Upsert(obj.Id, obj.ToJson()!);
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

    public async Task<BlaterResult<T>> Update(Ulid id, T obj)
    {
        ValidatePartition(id);

        var result = await store.Update(id, obj.ToJson()!);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        obj.Id = response;

        return obj;
    }

    public async Task<BlaterResult<T>> Insert(Ulid id, T obj)
    {
        if (obj.Id != Ulid.Empty)
        {
            return BlaterErrors.InvalidOperation("Id must be empty");
        }

        obj.Id = Ulid.New(Partition);

        var json = obj.ToJson();

        if (json == null)
        {
            return BlaterErrors.JsonSerializationError("Error in serialize json");
        }

        var result = await store.Insert(obj.Id, json);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        obj.Id = response;

        return obj;
    }

    public Task<BlaterResult<T>> Insert(T obj)
    {
        obj.Id = Ulid.NewUlid();
        return Insert(obj.Id, obj);
    }

    #endregion

    #region Changes

    public async IAsyncEnumerable<BlaterResult<T>> GetChangesQuery(BlaterQuery query)
    {
        var result = store.WatchChangesQuery(Partition, query, CancellationToken.None);

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

    public async Task<BlaterResult<bool>> Delete(Ulid id)
    {
        ValidatePartition(id);

        var result = await store.Delete(id);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }
        
        return response;
    }

    public async Task<BlaterResult<int>> Delete(List<Ulid> ids)
    {
        ids.ForEach(ValidatePartition);

        var result = await store.Delete(ids);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }
        
        return response;
    }

    public async Task<BlaterResult<int>> Delete(BlaterQuery query)
    {
        var result = await store.Delete(query);
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
        var result = await store.Count(Partition);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }
        
        return response;
    }

    #endregion
}*/