using Ardalis.Result;
using BuildingBlocks.CQRS;
using CreditTracker.Application.Data;
using CreditTracker.Domain.Models;

namespace CreditTracker.Application.Customers.Commands.VerifyOtp
{
    public class VerifyOtpHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork)
        : IQueryHandler<VerifyOtpCommand, Result<VerifyOtpResult>>
    {
        public async Task<Result<VerifyOtpResult>> Handle(VerifyOtpCommand command, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetById(command.Id);
            if (user is not null)
            {
                var isValid = user.VerifyOtp(command.Otp);
                if (isValid)
                {
                    userRepository.Update(user);
                    await unitOfWork.SaveChangesAsync(cancellationToken);
                }

                return Result.Success(new VerifyOtpResult(isValid));
            }
            else
            {
                return Result.NotFound("User not found");
            }
        }
    }
}
