namespace Salud_Amigos.App.Model.Error;
public record Errors(ErrorCode Code, IReadOnlyList<ErrorMessage> Messages)
{

    public static Errors General(params ErrorMessage[] messages)
    {
        return new Errors(ErrorCode.General, messages);
    }

    public static Errors NotFound(params ErrorMessage[] messages)
    {
        return new Errors(ErrorCode.NotFound, messages);
    }

    public static Errors BadRequest(params ErrorMessage[] messages)
    {
        return new Errors(ErrorCode.BadRequest, messages);
    }
}
