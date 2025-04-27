using Ardalis.Result;
using BuildingBlocks.CQRS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.Customers.Commands.VerifyOtp
{
    public record VerifyOtpCommand(string Id, string Otp) : IQuery<Result<VerifyOtpResult>>;
    public record VerifyOtpResult(bool IsSuccess);

    public class VerifyOtpCommandValidator : AbstractValidator<VerifyOtpCommand>
    {
        public VerifyOtpCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Otp).NotEmpty().WithMessage("Otp is required");
        }
    }
}
