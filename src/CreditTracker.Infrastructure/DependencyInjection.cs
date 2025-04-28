using CreditTracker.Application.Data;
using CreditTracker.Domain.Models;
using CreditTracker.Infrastructure.Data.Repositories;
using CreditTracker.Infrastructure.Data.Repositories.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CreditTracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetSection("Database:Connection").Value!;            
            var databaseName = config.GetSection("Database:Name").Value!;
            services.AddSingleton<IDbContext>(x => new DbContext(connectionString, databaseName));
            services.AddTransient(typeof(IRepository<User>), typeof(UserRepository<User>));
            services.AddTransient(typeof(IRepository<CreditEntry>), typeof(CreditEntryRepository<CreditEntry>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
