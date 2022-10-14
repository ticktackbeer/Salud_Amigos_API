using Microsoft.AspNetCore.Mvc;
using OneOf;
using OneOf.Types;
using Salud_Amigos.App.Model.Error;

namespace Salud_Amigos.Api.Helper
{
    public static class ActionResultExtensions
    {


        public static ActionResult<TDto> ToActionResult<T, TDto>(this T result, Func<T, TDto> createDto, int successStatusCode = StatusCodes.Status200OK)
        {

            return new ObjectResult(createDto(result)) { StatusCode = successStatusCode };
        }

        public static ActionResult<TDto> ToActionResult<T, TDto>(
        this OneOf<T, Errors> result,
        Func<T, TDto> createDto,
        int successStatusCode = StatusCodes.Status200OK)
        {
            return result.Match<ActionResult<TDto>>(
                t0 => new ObjectResult(createDto(t0)) { StatusCode = successStatusCode },
                t1 => CreateErrorResult(t1));
        }

        public static ActionResult ToActionResult(
        this OneOf<Success, Errors> result,
        int successStatusCode = StatusCodes.Status204NoContent)
        {
            return result.Match(_ => new StatusCodeResult(successStatusCode), CreateErrorResult);
        }

        private static ActionResult CreateErrorResult(Errors errors)
        {
            var problemDetails = ErrorsDto.FromModel(errors);
            return new ObjectResult(problemDetails)
            {
                StatusCode = problemDetails.Status,
                ContentTypes =
            {
                "application/problem+json"
            }
            };
        }

    }
}
