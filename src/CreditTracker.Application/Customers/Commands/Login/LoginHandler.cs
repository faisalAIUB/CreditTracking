using Ardalis.Result;
using BuildingBlocks.CQRS;
using BuildingBlocks.Helper;
using CreditTracker.Application.Data;
using CreditTracker.Application.Dtos;
using CreditTracker.Domain.Models;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace CreditTracker.Application.Customers.Commands.Login
{
    partial class LoginHandler(IRepository<User> userRepo, IConfiguration configuration) : ICommandHandler<LoginCommand, Result<LoginResult>>
    {
        public async Task<Result<LoginResult>> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await userRepo.GetSingle(x => x.UserName == command.UserName && x.IsVerified == true && x.IsActive == true);
            if (user is null)    
            {
                return Result.NotFound("User not found");
            }
            if(!PasswordHasher.Verify(command.Password, user.PasswordHash))
            {
                return Result.Invalid(new List<ValidationError> { new("Password", "Invalid password") });
            }
            var userDto = user.Adapt<UserDto>();
            var token = GenerateToken(userDto);
            return Result.Success(new LoginResult(token));
        }

        public string GenerateToken(UserDto user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
