namespace Salud_Amigos.App.Model.Error;
public record CreateUserAccountException() : ErrorMessage()
{
    public override string Message => "Failed to create UserAccount";
}
