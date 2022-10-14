namespace Salud_Amigos.App.Model.Error;
public record FriendRequestExistException() : ErrorMessage()
{
    public override string Message => "Friend Request already exist";
}
