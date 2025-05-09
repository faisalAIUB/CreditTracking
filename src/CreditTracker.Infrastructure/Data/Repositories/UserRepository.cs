﻿using CreditTracker.Application.Commons;
using CreditTracker.Application.Data;
using CreditTracker.Domain.Models;
using CreditTracker.Infrastructure.Data.Repositories.Core;

namespace CreditTracker.Infrastructure.Data.Repositories
{
    public class UserRepository<T> : Repository<T>, IRepository<T> where T : User
    {
        public UserRepository(IDbContext context, ICurrentUserService currentUserService) : base(context, currentUserService)
        {
        }
    }
}
