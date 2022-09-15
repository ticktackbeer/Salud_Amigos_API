using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salud_Amigos.Storage.Entities
{
    public class FriendEntity
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; } 
        public string Email { get; set; } = string.Empty;
        public string EmailFriend { get; set; } = string.Empty;
       
    }
}
