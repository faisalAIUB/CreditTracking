using CreditTracker.Domain.Models;
using MongoDB.Bson.Serialization;


namespace CreditTracker.Infrastructure.Map
{
    public class CreditEntryMapper
    {
        public static void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(CreditEntry)))
            {
                BsonClassMap.RegisterClassMap<CreditEntry>(x =>
                {
                    x.AutoMap();
                });
            }
        }
    }
}
