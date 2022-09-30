using Salud_Amigos.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salud_Amigos.App.Interface
{
    public interface IRepository
    {

        Task<UserAccountModel> CreateUserAccount(string email, string nickName, string name, string password, int age);
        Task<List<UserAccountModel>> GetUsersByEmail(List<string> emails);
        Task<List<UserAccountModel>> GetUsersBySearchText(string searchText);
        Task<FriendModel> CreateFriend(Guid userId, Guid userIdFriend, string email, string emailFriend);
        Task<int> CreateFriendRequest(UserAccountModel userAccount, UserAccountModel userAccountModelFriend);
        Task<TokenModel> CreateToken(Guid userId, string token, string email);
        Task<List<FriendModel>> GetFriendsByEmail(string email);

    }
}
