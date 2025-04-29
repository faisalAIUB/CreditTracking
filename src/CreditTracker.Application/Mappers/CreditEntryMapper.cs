using CreditTracker.Application.Dtos;
using CreditTracker.Domain.Models;
using Mapster;


namespace CreditTracker.Application.Mappers
{
    internal class CreditEntryMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreditEntry, CreditEntryDto>()
                .IgnoreNonMapped(true)
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.CustomerId, src => src.CustomerId)
                .Map(dest => dest.ShopId, src => src.ShopId)
                .Map(dest => dest.IsPaid, src => src.IsPaid)
                .Map(dest => dest.Item, src => src.Item)
                .Map(dest => dest.Amount, src => src.Amount)
                .Map(dest => dest.Date, src => src.Date)
                .Map(dest => dest.PaymentDate, src => src.PaymentDate);
        }
    }
}
