using System.Linq.Expressions;
using Blater.Exceptions;
using Blater.Interfaces;
using Blater.JsonUtilities;
using Blater.Models.Bases;
using Blater.Query.Extensions;
using Blater.Query.Interfaces;
using Blater.SDK.Implementations.BlaterDatabase.Stores;
using Blater.SDK.Interfaces;

namespace Blater.SDK.Implementations.BlaterDatabase.Repositories;

public class BlaterDatabaseRepositoryEndPoints<T>(IBlaterDatabaseEndpoints endPoints) 
    : IBlaterDatabaseRepository<T>
    where T : BaseDataModel
{
    private readonly string _partition = typeof(T).FullName?.SanitizeString() ?? throw new BlaterException("Could not get the type name of the entity");
    
    public async Task<T?> FindOne(BlaterId id)
    {
        var result = await endPoints.Get(id);
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
        
        var result = await endPoints.QueryOne(_partition, query);
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
        
        var result = await endPoints.Query(_partition, query);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        var models = response.Select(x => x.FromJson<T>()).ToReadOnlyList();

        return models;
    }
    
    public async Task<BlaterId> Upsert(T entity)
    {
        var result = await endPoints.Upsert(entity.Id, entity.ToJson()!);
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
    
    public async Task<BlaterId> Insert(T entity)
    {
        var result = await endPoints.Insert(entity.Id, entity.ToJson()!);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }
    
    public async Task<BlaterId> Update(T entity)
    {
        var result = await endPoints.Update(entity.Id, entity.ToJson()!);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }

        return response;
    }
    
    public async Task<bool> Delete(T entity)
    {
        var result = await endPoints.Delete(entity.Id);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async Task<bool> Delete(BlaterId id)
    {
        var result = await endPoints.Delete(id);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async Task<int> DeleteMany(Expression<Func<T, bool>> predicate)
    {
        var blaterQuery = predicate.ExpressionToBlaterQuery();
        var result = await endPoints.Delete(blaterQuery);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async Task<int> Count()
    {
        var result = await endPoints.Count(_partition);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async Task<int> Count(Expression<Func<T, bool>> predicate)
    {
        var blaterQuery = predicate.ExpressionToBlaterQuery();
        var result = await endPoints.Count(_partition, blaterQuery);
        if (result.HandleErrors(out var errors, out var response))
        {
            throw new BlaterException(errors);
        }
        
        return response;
    }
    
    public async IAsyncEnumerable<string> GetChangesQuery(Expression<Func<T, bool>> predicate)
    {
        var blaterQuery = predicate.ExpressionToBlaterQuery();
        var result = endPoints.WatchChangesQuery(_partition, blaterQuery);


        await foreach (var item in result)
        {
            if (item.HandleErrors(out var errors, out var response))
            {
                throw new BlaterException(errors);
            }

            yield return response;
        }
    }
    
    public IBlaterQueryable<T> Queryable { get; } = default!;
}