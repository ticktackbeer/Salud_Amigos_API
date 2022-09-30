using System.ComponentModel.DataAnnotations;

namespace Salud_Amigos.App.Model
{
    public record FriendModel
    {


        public FriendModel(Guid id, Guid userId,Guid userIdFriend, string email, string emailFriend, TokenModel token,UserAccountModel userAccountModel)
        {
            Id = id;
            UserId = userId;
            UserIdFriend = userIdFriend;
            Email = email;
            EmailFriend = emailFriend;
            Token = token;
            UserAccountFriend = userAccountModel;
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid UserIdFriend { get; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string Email { get; }
        public string EmailFriend { get; }
        public TokenModel Token { get; }
        public UserAccountModel UserAccountFriend { get; }
    
        
    }
}
