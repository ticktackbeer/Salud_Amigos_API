using Salud_Amigos.App.Model;
using System.Xml.Linq;

namespace Salud_Amigos.Storage.Entities
{
    public record TokenEntity
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTimeOffset Timestamp { get; set; }

        public TokenModel ToModel()
        {

            return new TokenModel(
                  Id,
                  UserId,
                  Token,
                  Email);

        }

    }
}
