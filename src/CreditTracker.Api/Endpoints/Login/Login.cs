using BuildingBlocks.Helper;
using Carter;
using CreditTracker.Application.Customers.Commands.Login;
using Mapster;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Swashbuckle.AspNetCore.Annotations;

namespace CreditTracker.Api.Endpoints.Login
{
    public record LoginRequest(string UserName, string Password);
    public record LoginResponse(string Token);
    public class Login : ICarterModule
    {

        public void AddRoutes(IEndpointRouteBuilder app)
        {

            app.MapPost("/login", async (LoginRequest request, ISender sender) =>
            {
                var command = request.Adapt<LoginCommand>();
                var result = await sender.Send(command);
                return result.Value;
            }).WithName("Login")
            .Produces<LoginResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Login")
            .WithDescription("Login")
            .WithMetadata(new SwaggerOperationAttribute(
                summary: "Login",
                description: "Login"
            ));
        }
    }
}
