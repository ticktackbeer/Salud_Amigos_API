using OneOf;
using OneOf.Types;
using Salud_Amigos.App.Model;
using Salud_Amigos.App.Model.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salud_Amigos.App.Interface
{
    public interface IFriendService
    {

        Task<OneOf<Success,Errors>> CreateFriend(Guid userId, Guid userIdFriend, string email, string emailFriend,Guid FriendRequestId);
        Task<OneOf<Success, Errors>> CreateFriendRequest(UserAccountModel userAccount, UserAccountModel userAccountModelFriend);
        Task<OneOf<List<FriendModel>, Errors>> GetFriends(string email);
        Task<OneOf<List<FriendRequestModel>, Errors>> GetReceivedFriendRequest(string email);
        Task<OneOf<List<FriendRequestModel>, Errors>> GetSendFriendRequest(string email);
        Task<OneOf<Success, Errors>> DeleteFriendById(Guid userId);


    }
}
