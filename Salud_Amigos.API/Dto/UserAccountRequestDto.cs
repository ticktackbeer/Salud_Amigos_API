namespace Salud_Amigos.App.Model
{
    public record UserAccountRequestDto
    {

        public SingleUserAccountRequestDto? UserAccount { get; init; } = default(SingleUserAccountRequestDto);
        public SingleUserAccountRequestDto? UserAccountFriend { get; init; } = default(SingleUserAccountRequestDto);

    }
}
