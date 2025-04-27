using Ardalis.Result;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.Helper
{
    public static class ResultExtensions
    {
        public static Microsoft.AspNetCore.Http.IResult ToApiResult<TValue, TResponse>(this Result<TValue> result)
            where TValue : class
            where TResponse : class
        {
            return result.Status switch
            {
                ResultStatus.Ok => Results.Ok(result.Value.Adapt<TResponse>()),
                ResultStatus.Conflict => Results.Conflict(result.Errors),
                ResultStatus.Invalid => Results.BadRequest(result.ValidationErrors),
                ResultStatus.NotFound => Results.NotFound(result.Errors),
                ResultStatus.Unauthorized => Results.Unauthorized(),
                _ => Results.BadRequest(result.Errors)
            };
        }
    }
}
