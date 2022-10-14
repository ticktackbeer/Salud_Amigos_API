namespace Salud_Amigos.App.Model.Error;
public record ErrorsDto(int Status, ErrorMessageDto[] Messages)
{
    public static ErrorsDto FromModel(Errors errors)
    {
        var messages = errors.Messages.Select(ErrorMessageDto.FromModel);
        var statusCode = errors.Code switch
        {
            ErrorCode.General => 400,
            ErrorCode.BadRequest => 400,
            ErrorCode.ValidationFailed => 400,
            ErrorCode.NotFound => 404,
            _ => 400,
        };
        return new ErrorsDto(Status: statusCode, Messages: messages.ToArray());
    }
}
