using System.ComponentModel.DataAnnotations;

namespace Salud_Amigos.Api.Dto
{
    public record FriendDto
    {
        [Required(ErrorMessage = "UserId address is required.")]
        public Guid UserId { get; init; } = default(Guid);

        [Required(ErrorMessage = "UserIdFriend address is required.")]
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
