namespace Salud_Amigos.App.Model.Error;
public record FriendExistException() : ErrorMessage()
{
    public override string Message => "Friend already exist";
}
