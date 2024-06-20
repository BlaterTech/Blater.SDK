using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Blater.Interfaces;
using Blater.Query.Extensions;
using Blater.Query.Interfaces;
using Blater.Results;

namespace Blater.SDK.Implementations;

public class BlaterDatabaseRepositoryEndPoints<T>(BlaterDatabaseStoreEndPoints storeEndPoints) where T : BaseDataModel, IBlaterDatabaseRepository<T>
{
    public Task<BlaterResult<T?>> FindOne(BlaterId id)
    {
        return storeEndPoints.Get<T?>($"{endpoint}/{id}");
    }
    
    public Task<BlaterResult<T?>> FindOne(Expression<Func<T, bool>> predicate)
    {
        var query = predicate.ExpressionToBlaterQuery();
        
        if (query == null)
        {
            return Task.FromResult(new BlaterResult<T>(new BlaterError("Query Error")));
        }
        return storeEndPoints.Post<T?>($"{endpoint}", query);
    }
    
    public Task<T?> FindOne(string partition, Expression<Func<T, bool>> predicate)
    {
        var query = predicate.ExpressionToBlaterQuery();

        
        if (query == null)
        {
            return BlaterErrors.QueryError(predicate);
        }
        return storeEndPoints.Post<T?>($"{endpoint}", query);
    }
    
    public Task<IReadOnlyList<T?>> FindMany(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
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