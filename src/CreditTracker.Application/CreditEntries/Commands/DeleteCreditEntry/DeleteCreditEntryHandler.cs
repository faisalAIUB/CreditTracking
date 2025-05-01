using Ardalis.Result;
using BuildingBlocks.CQRS;
using BuildingBlocks.Exceptions;
using CreditTracker.Application.Data;
using CreditTracker.Application.Exception;
using CreditTracker.Domain.Models;


namespace CreditTracker.Application.CreditEntries.Commands.DeleteCreditEntry
{
    public class DeleteCreditEntryHandler(IRepository<CreditEntry> creditEntryRepo, IUnitOfWork unitOfWork)
        : ICommandHandler<DeleteCreditEntryCommand, Result<DeleteCreditEntryResult>>
    {
        public async Task<Result<DeleteCreditEntryResult>> Handle(DeleteCreditEntryCommand command, CancellationToken cancellationToken)
        {
            var creditEntry = await creditEntryRepo.GetById(command.Id);
            if (creditEntry == null)
            {
                throw new CreditEntryNotFoundException(command.Id);
            }
            creditEntry.Remove();
            creditEntryRepo.Update(creditEntry);
            await unitOfWork.SaveChangesAsync();
            return Result.Success(new DeleteCreditEntryResult(true));
        }
    }
}
