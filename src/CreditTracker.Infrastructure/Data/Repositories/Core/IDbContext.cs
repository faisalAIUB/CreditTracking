using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Infrastructure.Data.Repositories.Core
{
    public interface IDbContext : IDisposable
    {
        void AddCommand(Func<Task> func);

        Task<int> SaveChanges();

        void Reset();

        IMongoCollection<T> GetCollection<T>(string name);
    }
}
