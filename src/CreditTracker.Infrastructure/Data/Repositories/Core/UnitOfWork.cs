using CreditTracker.Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Infrastructure.Data.Repositories.Core
{
    public class UnitOfWork(IDbContext _context) : IUnitOfWork
    {

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await _context.SaveChanges();
            _context.Reset();
            return result;
        }
        public void Dispose() => _context.Dispose();
    }
}
