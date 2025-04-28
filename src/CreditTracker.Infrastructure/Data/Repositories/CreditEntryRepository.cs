using CreditTracker.Application.Commons;
using CreditTracker.Application.Data;
using CreditTracker.Domain.Models;
using CreditTracker.Infrastructure.Data.Repositories.Core;

namespace CreditTracker.Infrastructure.Data.Repositories
{
    public class CreditEntryRepository<T> : Repository<T>, IRepository<T> where T : CreditEntry
    {
        public CreditEntryRepository(IDbContext context, ICurrentUserService currentUserService) : base(context, currentUserService)
        {
        }
    }
}
