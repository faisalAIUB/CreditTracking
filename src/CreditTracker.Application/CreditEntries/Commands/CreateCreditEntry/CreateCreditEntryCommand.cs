using Ardalis.Result;
using BuildingBlocks.CQRS;
using CreditTracker.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.CreditEntries.Commands.CreateCreditEntry
{
    public record CreateCreditEntryCommand(CreditEntryDto CreditEntry) : ICommand<Result<CreateCreditEntryResult>>;
    public record CreateCreditEntryResult(string Id);
    public class CreateCreditEntryValidator : AbstractValidator<CreateCreditEntryCommand>
    {
        public CreateCreditEntryValidator()
        {
            RuleFor(x => x.CreditEntry.Item).NotEmpty().WithMessage("Item is required");
            RuleFor(x => x.CreditEntry.Amount).NotEmpty().GreaterThan(0).WithMessage("Amount is required");
            RuleFor(x => x.CreditEntry.Date).NotNull().NotEmpty().WithMessage("Date is required");
            RuleFor(x => x.CreditEntry.ShopId).NotNull().NotEmpty().WithMessage("Date is required");
            RuleFor(x => x.CreditEntry.CustomerId).NotNull().NotEmpty().WithMessage("Date is required");
        }
    }
}
