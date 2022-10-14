namespace Salud_Amigos.App.Model.Error;
public record FriendNotFoundException() : ErrorMessage()
{
    public override string Message => "Friend not found";
}
