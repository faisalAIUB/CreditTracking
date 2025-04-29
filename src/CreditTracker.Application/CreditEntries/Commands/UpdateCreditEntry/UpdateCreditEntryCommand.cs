using Ardalis.Result;
using BuildingBlocks.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.CreditEntries.Commands.UpdateCreditEntry
{
    public record UpdateCreditEntryCommand(string Id, bool IsPaid, DateTime PaymentDate):ICommand<Result<UpdateCreditEntryResult>>;
    public record UpdateCreditEntryResult(bool IsSuccess);


}
