using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FifthAve.Core.BaseEntities;
using FifthAve.Core.Database.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FifthAve.Core.Database
{
    public class BaseRepository<T> : IBaseRepository<T> where T : IBaseEntity
    {
        public BaseRepository(IDatabaseProvider provider, string? collectionName = null)
        {
            _collection = provider.GetCollection<T>(collectionName);
        }

        private readonly IMongoCollection<T> _collection;

        protected virtual FilterDefinition<T> MandatoryFilter => Builders<T>.Filter.Empty;

        protected virtual void BeforeAdd(T entity) { }

        protected virtual void BeforeUpdate(T entity) { }

        protected virtual void BeforeDelete(ObjectId id) { }

        private FilterDefinition<T> QuerySingleEntity(ObjectId entityId)
            => MandatoryFilter == Builders<T>.Filter.Empty ?
                Builders<T>.Filter.Eq(x => x.Id, entityId) :
                Builders<T>.Filter.Eq(x => x.Id, entityId) & MandatoryFilter;

        private FilterDefinition<T> QueryMultipleEntities(IReadOnlyCollection<ObjectId> entityIds)
            => MandatoryFilter == Builders<T>.Filter.Empty ?
                Builders<T>.Filter.In(x => x.Id, entityIds) :
                Builders<T>.Filter.In(x => x.Id, entityIds) & MandatoryFilter;

        public async Task<T> GetAsync(ObjectId id, CancellationToken cancellationToken = default)
        {
            if (id == null || id == ObjectId.Empty)
                throw new ArgumentException("Can not be null or empty", nameof(id));

            var filter = QuerySingleEntity(id);
            var cursor = await _collection.FindAsync(filter, cancellationToken: cancellationToken).ConfigureAwait(false);
            return cursor.FirstOrDefault();
        }

        public async Task<IReadOnlyCollection<T>> GetManyAsync(IReadOnlyCollection<ObjectId> ids, CancellationToken cancellationToken = default)
        {
            if (ids == null || ids.Any(x => x == null || x == ObjectId.Empty))
                throw new ArgumentNullException(nameof(ids));
            
            var filter = QueryMultipleEntities(ids);
            var cursor = await _collection.FindAsync(filter, cancellationToken: cancellationToken).ConfigureAwait(false);
            return await cursor.ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            var filter = MandatoryFilter & Builders<T>.Filter.Where(predicate);
            var cursor = await _collection.FindAsync(filter, cancellationToken: cancellationToken).ConfigureAwait(false);
            return cursor.FirstOrDefault();
        }

        public async Task<IReadOnlyCollection<T>> FindManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            var filter = MandatoryFilter & Builders<T>.Filter.Where(predicate);
            var cursor = await _collection.FindAsync(filter, cancellationToken: cancellationToken).ConfigureAwait(false);
            return await cursor.ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task InsertAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            BeforeAdd(entity);

            await _collection.InsertOneAsync(entity, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task InsertManyAsync(IReadOnlyCollection<T> entities, CancellationToken cancellationToken = default)
        {
            if (entities == null || entities.Any(x => x == null))
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
            {
                BeforeAdd(entity);
            }

            await _collection.InsertManyAsync(entities, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task PatchAsync(ObjectId entityId, CancellationToken cancellationToken = default, params (Expression<Func<T, object>> propertyAccessor, object newValue)[] patchers)
        {
            if (entityId == null || entityId == ObjectId.Empty)
                throw new ArgumentException("Can not be null or empty", nameof(entityId));

            var filter = QuerySingleEntity(entityId);
            var updater = Builders<T>.Update.Combine(patchers.Select(x => Builders<T>.Update.Set(x.propertyAccessor, x.newValue)));
            await _collection.UpdateOneAsync(filter, updater, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task PatchAsync<TProperty>(ObjectId entityId, Expression<Func<T, TProperty>> propertyAccessor, TProperty newValue, CancellationToken cancellationToken = default)
        {
            if (entityId == null || entityId == ObjectId.Empty)
                throw new ArgumentException("Can not be null or empty", nameof(entityId));

            var filter = QuerySingleEntity(entityId);
            var updater = Builders<T>.Update.Set(propertyAccessor, newValue);
            await _collection.UpdateOneAsync(filter, updater, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            BeforeUpdate(entity);

            var filter = QuerySingleEntity(entity.Id);
            await _collection.ReplaceOneAsync(filter, entity, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public Task DeleteAsync(ObjectId id, CancellationToken cancellationToken = default)
        {
            if (id == null || id == ObjectId.Empty)
                throw new ArgumentException("Can not be null or empty", nameof(id));

            BeforeDelete(id);

            var filter = MandatoryFilter & Builders<T>.Filter.Eq(x => x.Id, id);
            return _collection.DeleteOneAsync(filter, cancellationToken);
        }

        public async Task<DeletingResult> DeleteManyAsync(IReadOnlyCollection<ObjectId> ids, CancellationToken cancellationToken = default)
        {
            if (ids == null || ids.Any(x => x == null || x == ObjectId.Empty))
                throw new ArgumentException("Can not be null or empty", nameof(ids));

            var filter = MandatoryFilter & Builders<T>.Filter.In(x => x.Id, ids);
            var result = await _collection.DeleteManyAsync(filter, cancellationToken).ConfigureAwait(false);
            return new DeletingResult { Deleted = result.DeletedCount };
        }

        public async Task<DeletingResult> DeleteWhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            var filter = MandatoryFilter & Builders<T>.Filter.Where(predicate);
            var result = await _collection.DeleteManyAsync(filter, cancellationToken).ConfigureAwait(false);
            return new DeletingResult { Deleted = result.DeletedCount };
        }
    }
}