using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salud_Amigos.Storage.Entities
{
    public class FriendRequestEntity
    {

        public Guid Id { get; set; }

        public string RequestFromEmail { get; set; } = string.Empty;
        public string RequestToEmail { get; set; } = string.Empty;
        public Guid RequestFromUserId { get; set; } 
        public Guid RequestToUserId { get; set; } 
        public string RequestFromNickName { get; set; } = string.Empty;
        public string RequestToNickName { get; set; } = string.Empty;
       
      
    }
}
