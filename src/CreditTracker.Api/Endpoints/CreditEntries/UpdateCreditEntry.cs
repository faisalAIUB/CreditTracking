﻿using BuildingBlocks.Helper;
using Carter;
using CreditTracker.Application.CreditEntries.Commands.UpdateCreditEntry;
using Mapster;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace CreditTracker.Api.Endpoints.CreditEntries
{
    public record UpdateCreditEntryRequest(string Id, bool IsPaid, DateTime PaymentDate);
    public record UpdateCreditEntryResponse(bool IsSuccess);
    public class UpdateCreditEntry : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/creditentry", async (UpdateCreditEntryRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateCreditEntryCommand>();
                var result = await sender.Send(command);
                return result.ToApiResult<UpdateCreditEntryResult, UpdateCreditEntryResponse>();
            })
                .RequireAuthorization("ShopPolicy")
                .WithName("Update Credit Entry")
                .Produces<UpdateCreditEntryResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Update Credit Entry")
                .WithDescription("Update Credit Entry")
                .WithMetadata(new SwaggerOperationAttribute(
                    summary: "Update a Credit Entry",
                    description: "Returns boolean"
                ));
        }
    }
}
