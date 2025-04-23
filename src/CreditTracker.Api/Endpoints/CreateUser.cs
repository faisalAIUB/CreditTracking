using Ardalis.Result;
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
                return result switch
                {
                    { Status: ResultStatus.Ok } => Results.Ok(result.Value.Adapt<CreateUserResponse>()),
                    { Status: ResultStatus.Conflict } => Results.Conflict(result.Errors),
                    { Status: ResultStatus.Invalid } => Results.BadRequest(result.ValidationErrors),
                    _ => Results.BadRequest(result.Errors)
                };
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
