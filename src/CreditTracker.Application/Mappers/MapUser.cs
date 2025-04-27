using CreditTracker.Application.Dtos;
using CreditTracker.Domain.Models;
using Mapster;


namespace CreditTracker.Application.Mappers
{
    internal class MapUser : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {          
            // User ➔ UserDto
            config.NewConfig<User, UserDto>()
                .IgnoreNonMapped(true)
                .Map(dest => dest.Id, src => src.Id) 
                .Map(dest => dest.UserName, src => src.UserName)
               
                .Map(dest => dest.Role, src => src.Role)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Address, src => src.Address)
                .Map(dest => dest.Latitude, src => src.Latitude)
                .Map(dest => dest.Longitude, src => src.Longitude);
        }
    }
}
