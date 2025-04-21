using Carter;
using CreditTracker.Application.Customers.Commands.CreateUser;
using CreditTracker.Application.Dtos;
using Mapster;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace CreditTracker.Api.Endpoints
{

    public record CreateUserRequest(UserDto User);
    public record CreateUserResponse(string Id);
    public class CreateUser : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/users", async (CreateUserRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateUserCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateUserResponse>();
                return Results.Created("",response);
            })
             .WithName("CreateUser")
            .Produces<CreateUserResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create User")
            .WithDescription("Create User")
            .WithMetadata(new SwaggerOperationAttribute(
                summary: "Create a user",
                description: "Returns user id"
            ));
        }
    }
}
