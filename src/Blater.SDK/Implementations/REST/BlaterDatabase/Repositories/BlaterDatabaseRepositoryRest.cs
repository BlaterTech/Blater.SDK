﻿/*using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Blater.Exceptions;
using Blater.Models.Bases;

namespace Blater.SDK.Implementations.REST.BlaterDatabase.Repositories;

public class BlaterDatabaseRepositoryRest<T>(IBlaterDatabaseStore store) 
    : IBlaterDatabaseRepository<T>
    where T : BaseDataModel
{
    private readonly string _partition = typeof(T).FullName?.SanitizeString() ?? throw new BlaterException("Could not get the type name of the entity");
    
    public async Task<T?> FindOne(Ulid id)
    {
        var result = await store.Get(id);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        var model = response.FromJson<T>();
        return model;
    }
    
    public async Task<T?> FindOne(Expression<Func<T, bool>> predicate)
    {
        var query = predicate.ExpressionToBlaterQuery();
        
        var result = await store.QueryOne(_partition, query);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        var model = response.FromJson<T>();
        return model;
    }
    
    public async Task<IReadOnlyList<T?>> FindMany(Expression<Func<T, bool>> predicate)
    {
        var query = predicate.ExpressionToBlaterQuery();
        
        var result = await store.Query(_partition, query);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        var models = response.Select(x => x.FromJson<T>()).ToReadOnlyList();

        return models;
    }
    
    public async Task<Ulid> Upsert(T entity)
    {
        var result = await store.Upsert(entity.Id, entity.ToJson()!);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        if (response == null)
        {
            throw new BlaterException($"Error in upsert by entity id: {entity.Id}");
        }

        return response;
    }
    
    public async Task<Ulid> Insert(T entity)
    {
        var result = await store.Insert(entity.Id, entity.ToJson()!);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }
    
    public async Task<Ulid> Update(T entity)
    {
        var result = await store.Update(entity.Id, entity.ToJson()!);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }
    
    public async Task<bool> Delete(T entity)
    {
        var result = await store.Delete(entity.Id);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async Task<bool> Delete(Ulid id)
    {
        var result = await store.Delete(id);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async Task<int> DeleteMany(Expression<Func<T, bool>> predicate)
    {
        var blaterQuery = predicate.ExpressionToBlaterQuery();
        var result = await store.Delete(blaterQuery);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async Task<int> Count()
    {
        var result = await store.Count(_partition);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async Task<int> Count(Expression<Func<T, bool>> predicate)
    {
        var blaterQuery = predicate.ExpressionToBlaterQuery();
        var result = await store.Count(_partition, blaterQuery);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async IAsyncEnumerable<string> GetChangesQuery(Expression<Func<T, bool>> predicate, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var blaterQuery = predicate.ExpressionToBlaterQuery();
        var result = store.WatchChangesQuery(_partition, blaterQuery, cancellationToken);


        await foreach (var item in result)
        {
            if (item.HandleErrors(out var errors, out var response))
            {
                throw new BlaterException(errors);
            }

            yield return response;
        }
    }
    
    public IBlaterQueryable<T> Queryable { get; set; } = default!;
}*/