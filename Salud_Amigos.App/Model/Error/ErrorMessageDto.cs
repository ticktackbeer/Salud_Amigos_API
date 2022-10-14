namespace Salud_Amigos.App.Model.Error;
public record ErrorMessageDto(
    string Code,
    string Message
)
{
    public static ErrorMessageDto FromModel(ErrorMessage model)
    {
        return new ErrorMessageDto(
            model.Code,
            model.Message);
    }
}