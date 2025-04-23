using Ardalis.Result;
using BuildingBlocks.CQRS;
using BuildingBlocks.Helper;
using CreditTracker.Application.Data;
using CreditTracker.Application.Dtos;
using CreditTracker.Domain.Models;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.Customers.Commands.CreateUser
{
    public class CreateUserHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork)
        : ICommandHandler<CreateUserCommand, Result<CreateUserResult>>
    {
        public async Task<Result<CreateUserResult>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (await userRepository.Any(x => x.UserName == command.User.UserName && x.IsVerified && x.IsActive))
            {
                return Result.Conflict("User already exists.");
            }
            var otp = GenerateOtp();
            var otpExpiry = DateTime.UtcNow.AddMinutes(5);
            var user = CreateNewUser(command.User, otp, otpExpiry);
            userRepository.Add(user);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            await SendOtp(otp);
            return Result.Success(new CreateUserResult(user.Id));
        }
        private User CreateNewUser(UserDto userDto, string otp, DateTime expiry)
        {
            var newUser = User.Create(userDto.UserName, userDto.Email, PasswordHasher.Hash(userDto.Password),userDto.Role, userDto.Name,userDto.Address, userDto.Latitude, userDto.Longitude);
            newUser.SetOtp(otp, expiry);
            return newUser;
        }
        private string GenerateOtp()
        {
            return new Random().Next(100000, 999999).ToString();
        }
        private async Task SendOtp(string otp)
        {
            await userRepository.CountAsync(x => x.OtpCode == otp);
        }
    }
}
