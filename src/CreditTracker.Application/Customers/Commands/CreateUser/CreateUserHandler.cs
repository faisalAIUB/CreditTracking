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
using System.Text;
using System.Threading.Tasks;

namespace CreditTracker.Application.Customers.Commands.CreateUser
{
    public class CreateUserHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork)
        : ICommandHandler<CreateUserCommand, CreateUserResult>
    {
        public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = CreateNewUser(command.User);
            userRepository.Add(user);
            await unitOfWork.SaveChangesAsync();
            return new CreateUserResult(user.Id);
        }
        private User CreateNewUser(UserDto userDto)
        {
            var newUser = User.Create(userDto.UserName, userDto.Email, PasswordHasher.Hash(userDto.Password),userDto.Role, userDto.Name,userDto.Address, userDto.Latitude, userDto.Longitude);
            return newUser;
        }
    }
}
