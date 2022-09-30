using System.ComponentModel.DataAnnotations;

namespace Salud_Amigos.Api.Dto
{
    public record UserAccountDto       
    {
        [Required(ErrorMessage = "Email address is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string Email { get; init; } = string.Empty;
        
        [Required(ErrorMessage = "Token is required.")]
        public string Token { get; init; } = string.Empty;
        public string NickName { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        public string Password { get; init; } = string.Empty;
        public int Age { get; init; } 

    }

    
  
}
