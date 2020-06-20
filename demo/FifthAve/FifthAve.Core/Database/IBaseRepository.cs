using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FifthAve.Core.BaseEntities;
using FifthAve.Core.Database.Models;
using MongoDB.Bson;

namespace FifthAve.Core.Database
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        Task<T> GetAsync(ObjectId id, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<T>> GetManyAsync(IReadOnlyCollection<ObjectId> ids, CancellationToken cancellationToken = default);
        Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<T>> FindManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task InsertAsync(T entity, CancellationToken cancellationToken = default);
        Task InsertManyAsync(IReadOnlyCollection<T> entities, CancellationToken cancellationToken = default);
        Task PatchAsync(ObjectId entityId, CancellationToken cancellationToken = default, params (Expression<Func<T, object>> propertyAccessor, object newValue)[] patchers);
        Task PatchAsync<TProperty>(ObjectId entityId, Expression<Func<T, TProperty>> propertyAccessor, TProperty newValue, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(ObjectId id, CancellationToken cancellationToken = default);
        Task<DeletingResult> DeleteManyAsync(IReadOnlyCollection<ObjectId> ids, CancellationToken cancellationToken = default);
    }
}