using BuildingBlocks.CQRS;
using CreditTracker.Application.Data;
using CreditTracker.Application.Dtos;
using CreditTracker.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.Customers.Queries.SearchCustomer
{
    public class SearchCustomerHandler(IRepository<User> userRepo)
        : IQueryHandler<SearchCustomerQuery, SearchCustomerResult>
    {
        public async Task<SearchCustomerResult> Handle(SearchCustomerQuery query, CancellationToken cancellationToken)
        {
            var customers = await userRepo.TextSearchAsync(query.SearchText, x => x.Role == Domain.Enum.Role.Customer);
            if (customers == null || customers.Count == 0)
            {
                return new SearchCustomerResult(new List<UserDto>());
            }
            var userDtos = customers.Adapt<List<UserDto>>();
            return new SearchCustomerResult(userDtos);
        }
    }
}
