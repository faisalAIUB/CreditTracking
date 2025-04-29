using Ardalis.Result;
using BuildingBlocks.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.CreditEntries.Commands.DeleteCreditEntry
{
    public record DeleteCreditEntryCommand(string Id): ICommand<Result<DeleteCreditEntryResult>>;
    public record DeleteCreditEntryResult(bool IsSuccess);
}
