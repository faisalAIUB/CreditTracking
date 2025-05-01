using Ardalis.Result;
using BuildingBlocks.CQRS;
using CreditTracker.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.Customers.Queries.GetUser
{
    public record GetUserQuery(string Id):IQuery<Result<GetUserResult>>;
    public record GetUserResult(UserDto User);
   
}
