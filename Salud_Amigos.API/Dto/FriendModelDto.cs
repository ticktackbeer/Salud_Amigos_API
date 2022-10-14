using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Salud_Amigos.App.Model
{
    public record FriendModelDto
    {


        public FriendModelDto(Guid id, Guid userId,Guid userIdFriend, string email, string emailFriend, TokenModel token, SingleUserAccountRequestDto userAccountModelDto)
        {
            Id = id;
            UserId = userId;
            UserIdFriend = userIdFriend;
            Email = email;
            EmailFriend = emailFriend;
            Token = token;
            UserAccountFriendDto = userAccountModelDto;
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid UserIdFriend { get; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string Email { get; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string EmailFriend { get; }
        public TokenModel Token { get; }
        public SingleUserAccountRequestDto UserAccountFriendDto { get; }
    
        
        public static List<FriendModelDto> ToModel(List<FriendModel> model)
        {
            return model.ConvertAll(ToModel);
        }

        public static FriendModelDto ToModel(FriendModel model)
        {
            return new FriendModelDto(model.Id,
                model.UserId,
                model.UserIdFriend,
                model.Email,
                model.EmailFriend,
                model.Token,
                new SingleUserAccountRequestDto(model.UserAccountFriend.Id, model.UserAccountFriend.Email, model.UserAccountFriend.NickName));
        }
    }
}
