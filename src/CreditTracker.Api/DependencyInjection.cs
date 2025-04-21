using BuildingBlocks.Exceptions.Handler;
using Carter;
using HealthChecks.MongoDb;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CreditTracker.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCarter();
            var connectionString = configuration.GetSection("Database:Connection").Value!;
            var databaseName = configuration.GetSection("Database:Name").Value!;
            services.AddExceptionHandler<CustomExceptionHandler>();
            services.AddSingleton(new MongoDbHealthCheck(new MongoClient(connectionString), databaseName));
            services.AddHealthChecks()
                .AddMongoDb();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            app.MapCarter();

            app.UseExceptionHandler(options => { });
            app.UseHealthChecks("/health",
                new HealthCheckOptions
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
