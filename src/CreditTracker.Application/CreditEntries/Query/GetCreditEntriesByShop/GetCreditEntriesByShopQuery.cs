using Ardalis.Result;
using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using CreditTracker.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.CreditEntries.Query.GetCreditEntriesByShop
{
    
        public record GetCreditEntriesByShopQuery(PaginationRequest PaginationRequest, string ShopId) : IQuery<Result<GetCreditEntriesByShopResult>>;

        public record GetCreditEntriesByShopResult(PaginationResult<CreditEntryDto> CreditEntries);
    
}
