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
    public interface IRepository
    {

        Task<OneOf<UserAccountModel, Errors>> CreateUserAccount(string email, string nickName, string name, string password, int age);
        Task<OneOf<List<UserAccountModel>, Errors>> GetUsersByEmail(List<string> emails);
        Task<OneOf<List<UserAccountModel>, Errors>> GetUsersBySearchText(string searchText);
        Task<OneOf<Success, Errors>> DeleteUserById(Guid userId);
        Task<OneOf<Success,Errors>> CreateFriend(Guid userId, Guid userIdFriend, string email, string emailFriend, Guid friendRequestId);
        Task<OneOf<Success, Errors>> CreateFriendRequest(UserAccountModel userAccount, UserAccountModel userAccountModelFriend);
        Task<OneOf<Success, Errors>> DeleteFriendRequest(Guid FriendRequestId);
        Task<OneOf<TokenModel, Errors>> CreateToken(Guid userId, string token, string email);
        Task<OneOf<List<FriendModel>, Errors>> GetFriendsByEmail(string email);
        Task<OneOf<List<FriendRequestModel>, Errors>> GetReceivedFriendRequestByEmail(string email);
        Task<OneOf<List<FriendRequestModel>, Errors>> GetSendFriendRequestByEmail(string email);
        Task<OneOf<Success, Errors>> DeleteFriendById(Guid userId);
        Task<OneOf<Success, Errors>> DeleteFriendRelationById(Guid userId);

    }
}
