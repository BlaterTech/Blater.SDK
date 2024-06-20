using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Blater.Exceptions;
using Blater.Interfaces;
using Blater.JsonUtilities;
using Blater.Query.Extensions;
using Blater.Query.Interfaces;
using Blater.Results;

namespace Blater.SDK.Implementations;

public class BlaterDatabaseRepositoryEndPoints<T>(BlaterDatabaseStoreEndPoints storeEndPoints) 
    where T : BaseDataModel, 
    IBlaterDatabaseRepository<T>
{
    private readonly string _partition = typeof(T).FullName?.SanitizeString() ?? throw new BlaterException("Could not get the type name of the entity");

    public async Task<BlaterResult<T?>> FindOne(BlaterId id)
    {
        var result = await storeEndPoints.Get(id);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        var model = response.FromJson<T>();
        return model;
    }
    
    public async Task<BlaterResult<T?>> FindOne(Expression<Func<T, bool>> predicate)
    {
        var query = predicate.ExpressionToBlaterQuery();
        
        var result = await storeEndPoints.QueryOne(_partition, query);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }
        
        var model = response.FromJson<T>();
        return model;
    }
    
    public async Task<BlaterResult<T?>> FindOne(string partition, Expression<Func<T, bool>> predicate)
    {
        var query = predicate.ExpressionToBlaterQuery();
        
        var result = await storeEndPoints.QueryOne(partition, query);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }
        
        var model = response.FromJson<T>();
        return model;
    }
    
    public async Task<BlaterResult<IReadOnlyList<T?>>> FindMany(Expression<Func<T, bool>> predicate)
    {
        var query = predicate.ExpressionToBlaterQuery();
        
        var result = await storeEndPoints.Query(_partition, query);
        if (result.HandleErrors(out var errors, out var response))
        {
            return errors;
        }

        var models = response.Select(x => x.FromJson<T>()).ToReadOnlyList();

        return new BlaterResult<IReadOnlyList<T?>>(models);
    }
    
    public Task<IReadOnlyList<T?>> FindMany(string partition, Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterId> Upsert(T entity)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterId> Insert(T entity)
    {
        throw new NotImplementedException();
    }
    
    public Task<BlaterId> Update(T entity)
    {
        throw new NotImplementedException();
    }
    
    public Task<bool> Delete(T entity)
    {
        throw new NotImplementedException();
    }
    
    public Task<bool> Delete(BlaterId id)
    {
        throw new NotImplementedException();
    }
    
    public Task<int> DeleteMany(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }
    
    public Task<int> Count()
    {
        throw new NotImplementedException();
    }
    
    public Task<int> Count(string partition)
    {
        throw new NotImplementedException();
    }
    
    public Task<int> Count(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }
    
    [SuppressMessage("Design", "CA1024:Usar propriedades sempre que apropriado")]
    public IAsyncEnumerable<string> GetChanges()
    {
        throw new NotImplementedException();
    }
    
    public IAsyncEnumerable<string> GetChangesQuery(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }
    
    public IBlaterQueryable<T> Queryable { get; } = default!;
}