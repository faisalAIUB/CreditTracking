using Ardalis.Result;
using BuildingBlocks.CQRS;
using CreditTracker.Application.Dtos;
using CreditTracker.Domain.Enum;
using FluentValidation;

namespace CreditTracker.Application.Customers.Commands.CreateUser
{
    public record CreateUserCommand(UserDto User): ICommand<Result<CreateUserResult>>;
    public record CreateUserResult(string Id);

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        {
            RuleFor(x => x.User.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.User.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(x => x.User.ICNoOrPassport).NotEmpty().WithMessage("IC or passport is required");
            RuleFor(x => x.User.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.User.Role).Equal(Role.Customer).WithMessage("Only Customer role is allowed.");
        }
    }
}
