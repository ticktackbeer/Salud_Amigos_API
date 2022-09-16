using Salud_Amigos.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salud_Amigos.App.Interface
{
    public interface IFriendService
    {

        Task<FriendModel> CreateFriend(Guid userId, Guid userIdFriend, string email, string emailFriend);
        Task<List<FriendModel>> GetFriends(string email);


    }
}
