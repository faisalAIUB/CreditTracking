using Ardalis.Result;
using BuildingBlocks.CQRS;
using CreditTracker.Application.Data;
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
                return Result.NotFound();
            }
            creditEntry.Remove();
            creditEntryRepo.Update(creditEntry);
            await unitOfWork.SaveChangesAsync();
            return Result.Success(new DeleteCreditEntryResult(true));
        }
    }
}
