using Salud_Amigos.App.Interface;
using Salud_Amigos.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salud_Amigos.App.Service
{
    public class FriendService : IFriendService
    {
        private readonly IRepository _repository;
        public FriendService(IRepository repository)
        {
            _repository = repository;
        }



        public async Task<FriendModel> CreateFriend(Guid userId, Guid userIdFriend, string email, string emailFriend)
        {
            await _repository.CreateFriend(userId, userIdFriend, email, emailFriend);
            return await _repository.CreateFriend(userIdFriend, userId, emailFriend, email);  
        }

        public Task<int> CreateFriendRequest(UserAccountModel userAccount, UserAccountModel userAccountModelFriend)
        {
           return  _repository.CreateFriendRequest(userAccount, userAccountModelFriend);
        }

        public  async Task<List<FriendModel>> GetFriends(string email)
        {
            return await _repository.GetFriendsByEmail(email);
        }
    }
}
