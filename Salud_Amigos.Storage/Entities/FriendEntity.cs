using Salud_Amigos.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Salud_Amigos.Storage.Entities
{
    public class FriendEntity
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; } 
        public Guid UserIdFriend { get; set; } 
        public string Email { get; set; } = string.Empty;
        public string EmailFriend { get; set; } = string.Empty;
        public DateTimeOffset Timestamp { get; set; }
        public TokenEntity? Token { get; set; }

        public FriendModel ToModel()
        {

            return new FriendModel(
                  Id,
                  UserId,
                  UserIdFriend,
                  Email,
                  EmailFriend,
                  Token?.ToModel()?? TokenModel.EmptyModel());

        }
    }
}
