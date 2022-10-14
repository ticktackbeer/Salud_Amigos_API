namespace Salud_Amigos.App.Model.Error;
public record CreateFriendRequestException() : ErrorMessage()
{
    public override string Message => "Failed to create FriendRequest";
}
