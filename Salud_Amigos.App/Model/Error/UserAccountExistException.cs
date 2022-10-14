namespace Salud_Amigos.App.Model.Error;
public record UserAccountExistException() : ErrorMessage()
{
    public override string Message => "UserAccount already exist";
}
