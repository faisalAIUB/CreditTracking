using Ardalis.Result;
using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using CreditTracker.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.CreditEntries.Query.GetCreditEntriesByCustomer
{
    public record GetCreditEntriesByCustomerQuery(PaginationRequest PaginationRequest, string CustomerId): IQuery<Result<GetCreditEntriesByCustomerResult>>;

    public record GetCreditEntriesByCustomerResult(PaginationResult<CreditEntryDto> CreditEntries);

}
