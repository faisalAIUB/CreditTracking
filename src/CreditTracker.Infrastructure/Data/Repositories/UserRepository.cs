using CreditTracker.Application.Data;
using CreditTracker.Domain.Models;
using CreditTracker.Infrastructure.Data.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Infrastructure.Data.Repositories
{
    public class UserRepository<T> : Repository<T>, IRepository<T> where T : User
    {
        public UserRepository(IDbContext context) : base(context)
        {
        }
    }
}
