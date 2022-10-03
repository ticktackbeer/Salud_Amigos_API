using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Salud_Amigos.App.Model
{
    public record FriendRequestModelDto
    {


        public FriendRequestModelDto(Guid id, Guid userId,Guid userIdFriend, string email, string emailFriend, string requestFromNickName, string requestToNickName)
        {
            Id = id;
            UserId = userId;
            UserIdFriend = userIdFriend;
            Email = email;
            EmailFriend = emailFriend;
            RequestFromNickName = requestFromNickName;
            RequestToNickName = requestToNickName;
            
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
        public string RequestFromNickName { get; }         
        public  string RequestToNickName { get; }



        public static FriendRequestModelDto ToModel(FriendRequestModel model)
        {
          return  new FriendRequestModelDto(model.Id,
              model.RequestFromUserId,
              model.RequestToUserId,
              model.RequestFromEmail,
              model.RequestToEmail,
              model.RequestFromNickName,
              model.RequestToNickName);
        }
    }
}
