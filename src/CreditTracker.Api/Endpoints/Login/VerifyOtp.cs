using Ardalis.Result;
using BuildingBlocks.Helper;
using Carter;
using CreditTracker.Application.Customers.Commands.VerifyOtp;
using Mapster;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace CreditTracker.Api.Endpoints.Login
{
    public record VerifyOtpRequest(string Id, string Otp);
    public record VerifyOtpResponse(bool IsSuccess);

    public class VerifyOtp : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/users/verifyotp", async (VerifyOtpRequest request, ISender sender) =>
            {
                var command = request.Adapt<VerifyOtpCommand>();
                var result = await sender.Send(command);
                return result.Value;

            }).WithName("Verifyotp")
            .Produces<LoginResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Verifyotp")
            .WithDescription("Verifyotp")
            .WithMetadata(new SwaggerOperationAttribute(
                summary: "Verifyotp",
                description: "Verifyotp"
            ));
        }
    }
}
