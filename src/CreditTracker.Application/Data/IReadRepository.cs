using CreditTracker.Domain.Abstractions;
using System.Linq.Expressions;


namespace CreditTracker.Application.Data
{
    public interface IReadRepository<TEntity> : IDisposable where TEntity : class, IEntity
    {
        Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetByFilter(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetById(string id);

        Task<IQueryable<TEntity>> GetAll();

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAllByIds(List<string> keys);
        List<dynamic> GetSingleColumnList(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, dynamic>> selectPredicate);
    }
}
