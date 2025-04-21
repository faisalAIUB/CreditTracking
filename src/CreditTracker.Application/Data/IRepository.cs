using CreditTracker.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.Data
{
    public interface IRepository<TEntity> : IReadRepository<TEntity> where TEntity : class, IEntity
    {
        void Add(TEntity obj);
        void Update(TEntity obj);

        void Remove(string id);

        void RemoveMany(Expression<Func<TEntity, bool>> predicate);

        void Remove(Expression<Func<TEntity, bool>> predicate);
      
        void Reset();

        void UpdateMany(Expression<Func<TEntity, bool>> filterPredicate, Expression<Func<TEntity, dynamic>> updatePredicate, dynamic value);

        Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate);

        void ReplaceManyAsync(IEnumerable<TEntity> entities);

        void AddMany(IEnumerable<TEntity> objs);


    }
}
