using Ardalis.Result;
using BuildingBlocks.CQRS;
using CreditTracker.Application.Data;
using CreditTracker.Application.Dtos;
using CreditTracker.Domain.Models;


namespace CreditTracker.Application.CreditEntries.Commands.CreateCreditEntry
{
    public class CreateCreditEntryHandler(IRepository<CreditEntry> creditEntryRepository, IUnitOfWork unitOfWork)
        : ICommandHandler<CreateCreditEntryCommand, Result<CreateCreditEntryResult>>
    {
        public async Task<Result<CreateCreditEntryResult>> Handle(CreateCreditEntryCommand command, CancellationToken cancellationToken)
        {
            var creditEntry = CreateNew(command.CreditEntry);
            creditEntryRepository.Add(creditEntry);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(new CreateCreditEntryResult(creditEntry.Id));
        }

        private CreditEntry CreateNew(CreditEntryDto creditEntryDto)
        {
            return CreditEntry.Create(creditEntryDto.ShopId, creditEntryDto.CustomerId, creditEntryDto.Item, creditEntryDto.Amount, creditEntryDto.Date,
                creditEntryDto.IsPaid, creditEntryDto.PaymentDate);
        }

    }
}
