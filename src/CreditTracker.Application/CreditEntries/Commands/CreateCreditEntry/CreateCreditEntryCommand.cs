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
    public record CreateCreditEntryCommand(string ShopId, string CustomerId, string Item, decimal Amount, DateTime Date, bool IsPaid, DateTime? PaymentDate) : ICommand<Result<CreateCreditEntryResult>>;
    public record CreateCreditEntryResult(string Id);
    public class CreateCreditEntryValidator : AbstractValidator<CreateCreditEntryCommand>
    {
        public CreateCreditEntryValidator()
        {
            RuleFor(x => x.Item).NotEmpty().WithMessage("Item is required");
            RuleFor(x => x.Amount).NotEmpty().GreaterThan(0).WithMessage("Amount is required");
            RuleFor(x => x.Date).NotNull().NotEmpty().WithMessage("Date is required");
            RuleFor(x => x.ShopId).NotNull().NotEmpty().WithMessage("ShopId is required");
            RuleFor(x => x.CustomerId).NotNull().NotEmpty().WithMessage("Customer Id is required");
        }
    }
}
