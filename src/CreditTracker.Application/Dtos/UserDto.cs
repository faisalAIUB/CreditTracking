﻿using CreditTracker.Domain.Enum;


namespace CreditTracker.Application.Dtos
{
   public record UserDto(
       string Id, string UserName, string Password, string Name, string ICNoOrPassport, Role Role, string Email, string Address, string Latitude, string Longitude
       );
}
