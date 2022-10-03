using System.ComponentModel.DataAnnotations;

namespace Salud_Amigos.Api.Dto
{
    public record FriendDto
    {
        [Required(ErrorMessage = "FriendRequestId is required.")]
        public Guid FriendRequestId { get; init; } = default(Guid);
        
        [Required(ErrorMessage = "UserId is required.")]
        public Guid UserId { get; init; } = default(Guid);

        [Required(ErrorMessage = "UserIdFriend is required.")]
        public Guid UserIdFriend { get; init; } = default(Guid);
        
        [Required(ErrorMessage = "Email address is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string Email { get; init; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string EmailFriend { get; init; } = string.Empty;
       
    }

    
  
}
