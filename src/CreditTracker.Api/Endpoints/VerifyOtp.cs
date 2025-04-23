using Ardalis.Result;
using Carter;
using CreditTracker.Application.Customers.Commands.VerifyOtp;
using Mapster;
using MediatR;

namespace CreditTracker.Api.Endpoints
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
                return result switch
                {
                    { Status: ResultStatus.Ok } => Results.Ok(result.Value.Adapt<VerifyOtpResponse>()),
                    { Status: ResultStatus.NotFound } => Results.NotFound(result.Errors),
                    { Status: ResultStatus.Invalid } => Results.BadRequest(result.ValidationErrors),
                    _ => Results.BadRequest(result.Errors)
                };
            });
        }
    }
}
