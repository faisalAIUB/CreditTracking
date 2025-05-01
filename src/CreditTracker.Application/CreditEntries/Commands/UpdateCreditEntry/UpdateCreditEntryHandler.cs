using Ardalis.Result;
using BuildingBlocks.CQRS;
using BuildingBlocks.Exceptions;
using CreditTracker.Application.Data;
using CreditTracker.Application.Exception;
using CreditTracker.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.CreditEntries.Commands.UpdateCreditEntry
{
    public class UpdateCreditEntryHandler(IRepository<CreditEntry> creditEntryRepo, IUnitOfWork unitOfWork)
        : ICommandHandler<UpdateCreditEntryCommand, Result<UpdateCreditEntryResult>>
    {
        public async Task<Result<UpdateCreditEntryResult>> Handle(UpdateCreditEntryCommand command, CancellationToken cancellationToken)
        {
            var creditEntry = await creditEntryRepo.GetById(command.Id);
            if (creditEntry == null) 
            {
                throw new CreditEntryNotFoundException(command.Id);
            }
            creditEntry.Update(command.IsPaid, command.PaymentDate);
            creditEntryRepo.Update(creditEntry);
            await unitOfWork.SaveChangesAsync();
            return Result.Success(new UpdateCreditEntryResult(true));
        }
    }
}
