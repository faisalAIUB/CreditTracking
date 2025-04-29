using Ardalis.Result;
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

namespace CreditTracker.Application.CreditEntries.Query.GetCreditEntry
{
    public class GetCreditEntryHandler(IRepository<CreditEntry> creditEntryRepo) 
        : IQueryHandler<GetCreditEntryQuery, Result<GetCreditEntryResult>>
    {
        public async Task<Result<GetCreditEntryResult>> Handle(GetCreditEntryQuery query, CancellationToken cancellationToken)
        {
            var creditEntry = await creditEntryRepo.GetById(query.Id);
            if (creditEntry == null) 
            {
                return Result.NotFound();
            }
            var creditEntryDto = creditEntry.Adapt<CreditEntryDto>();
            return Result.Success(new GetCreditEntryResult(creditEntryDto));
        }
    }
}
