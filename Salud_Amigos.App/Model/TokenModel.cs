using System.ComponentModel.DataAnnotations;

namespace Salud_Amigos.App.Model
{
    public record TokenModel
    {
        public TokenModel(Guid id, Guid userId, string token, string email)
        {
            Id = id;
            UserId = userId;
            Email = email;
            Token = token;
         
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string Email { get; }
        public string Token { get; }

        public static TokenModel EmptyModel()
        {
            return new TokenModel(Guid.Empty,Guid.Empty,string.Empty,string.Empty);
        }
         
    }
}
