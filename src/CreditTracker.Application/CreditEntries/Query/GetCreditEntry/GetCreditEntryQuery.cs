using Ardalis.Result;
using BuildingBlocks.CQRS;
using CreditTracker.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.CreditEntries.Query.GetCreditEntry
{

    public record GetCreditEntryQuery(string Id): IQuery<Result<GetCreditEntryResult>>;
    public record GetCreditEntryResult(CreditEntryDto CreditEntry);
}
