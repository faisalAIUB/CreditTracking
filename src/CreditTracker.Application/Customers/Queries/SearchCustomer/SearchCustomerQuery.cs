using BuildingBlocks.CQRS;
using CreditTracker.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.Customers.Queries.SearchCustomer
{
    public record SearchCustomerQuery(string SearchText): IQuery<SearchCustomerResult>;
    public record SearchCustomerResult(List<UserDto> Users);
}
