using System.ComponentModel.DataAnnotations;

namespace Salud_Amigos.App.Model
{
    public record FriendRequestModel
    {


        public FriendRequestModel(Guid id, Guid userId,Guid userIdFriend, string email, string emailFriend, string requestFromNickName, string requestToNickName)
        {
            Id = id;
            RequestFromUserId = userId;
            RequestToUserId = userIdFriend;
            RequestFromEmail = email;
            RequestToEmail = emailFriend;
            RequestFromNickName = requestFromNickName;
            RequestToNickName = requestToNickName;
            
        }

        public Guid Id { get; }
        public Guid RequestFromUserId { get; }
        public Guid RequestToUserId { get; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string RequestFromEmail { get; }
        public string RequestToEmail { get; }
        public string RequestFromNickName { get; } 
        public string RequestToNickName { get;}




    }
}
