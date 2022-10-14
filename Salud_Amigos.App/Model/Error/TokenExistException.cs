namespace Salud_Amigos.App.Model.Error;
public record TokenExistException() : ErrorMessage()
{
    public override string Message => "Token already exist";
}
