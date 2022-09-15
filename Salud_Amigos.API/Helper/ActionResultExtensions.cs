using Microsoft.AspNetCore.Mvc;

namespace Salud_Amigos.Api.Helper
{
    public static class ActionResultExtensions
    {


        public static ActionResult<TDto> ToActionResult<T, TDto>(this T result, Func<T, TDto> createDto, int successStatusCode = StatusCodes.Status200OK)
        {

            return new ObjectResult(createDto(result)) { StatusCode = successStatusCode };
        }

    }
}
