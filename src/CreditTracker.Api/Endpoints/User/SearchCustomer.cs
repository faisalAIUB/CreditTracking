using Carter;
using CreditTracker.Application.Customers.Queries.SearchCustomer;
using CreditTracker.Application.Dtos;
using MediatR;

namespace CreditTracker.Api.Endpoints.User
{
    public record SearchCustomerResponse(List<UserDto> Users);
    public class SearchCustomer : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/user/{searchText}", async (string SearchText, ISender sender) =>
            {
                var query = new SearchCustomerQuery(SearchText);
                var result = await sender.Send(query);
                return Results.Ok(result);
            });
        }
    }
}
