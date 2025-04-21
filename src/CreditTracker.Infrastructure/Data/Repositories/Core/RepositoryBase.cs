using CreditTracker.Application.Data;
using CreditTracker.Domain.Abstractions;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Infrastructure.Data.Repositories.Core
{
    public abstract class RepositoryBase<TEntity> 
    {
        protected IDbContext _context;
        protected IMongoCollection<TEntity> DbSet;
        protected RepositoryBase(IDbContext context)
        {
            _context = context;
            DbSet = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }
    }

    public abstract class Repository<TEntity> : ReadRepository<TEntity>, IRepository<TEntity> where TEntity : class, IEntity<string>
    {
        protected Repository(IDbContext context) : base(context)
        {

        }
        public void Add(TEntity obj)
        {
            _context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        public void AddMany(IEnumerable<TEntity> objs)
        {
            _context.AddCommand(() => DbSet.InsertManyAsync(objs));
        }

        public async Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var filter = Builders<TEntity>.Filter.Where(predicate);
            var count = await DbSet.CountDocumentsAsync(filter);
            return count;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public virtual void Remove(string id)
        {
            var objectId = new ObjectId(id);
            _context.AddCommand(() => DbSet.DeleteOneAsync(x => x.Id == id));
        }

        public virtual void Remove(Expression<Func<TEntity, bool>> predicate)
        {
            _context.AddCommand(() => DbSet.DeleteOneAsync(predicate));
        }

        public virtual void RemoveMany(Expression<Func<TEntity, bool>> predicate)
        {
            _context.AddCommand(async () => await DbSet.DeleteManyAsync(predicate));
        }

        public virtual void ReplaceManyAsync(IEnumerable<TEntity> entities)
        {
            var updates = new List<WriteModel<TEntity>>();
            var filterBuilder = Builders<TEntity>.Filter;

            foreach (var doc in entities)
            {
                var filter = filterBuilder.Where(x => x.Id == doc.Id);
                updates.Add(new ReplaceOneModel<TEntity>(filter, doc));
            }
            _context.AddCommand(() => DbSet.BulkWriteAsync(updates));
        }

        public void Reset()
        {
            _context?.Reset();
        }

        public virtual void Update(TEntity obj)
        {            
            var dbEntity = obj as IEntity<string>;            
            _context.AddCommand(() => DbSet.ReplaceOneAsync(x => x.Id == dbEntity.Id, obj));
        }

        public virtual void UpdateMany(Expression<Func<TEntity, bool>> filterPredicate, Expression<Func<TEntity, dynamic>> updatePredicate, dynamic value)
        {
            var update = Builders<TEntity>.Update.Set<dynamic>(updatePredicate, value);
            var filter = Builders<TEntity>.Filter.Where(filterPredicate);
            _context.AddCommand(() => DbSet.UpdateManyAsync(filter, update));
        }
    }
}
