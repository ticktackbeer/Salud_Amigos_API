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



        public async Task<FriendModel> CreateFriend(Guid userId, Guid userIdFriend, string email, string emailFriend,Guid FriendRequestId)
        {
            await _repository.CreateFriend(userId, userIdFriend, email, emailFriend);
            var returnValue= await _repository.CreateFriend(userIdFriend, userId, emailFriend, email);  
            await _repository.DeleteFriendRequest(FriendRequestId);
            return returnValue;
        }

        public Task<int> CreateFriendRequest(UserAccountModel userAccount, UserAccountModel userAccountModelFriend)
        {
           return  _repository.CreateFriendRequest(userAccount, userAccountModelFriend);
        }

        public  async Task<List<FriendModel>> GetFriends(string email)
        {
            return await _repository.GetFriendsByEmail(email);
        }

        public async Task<List<FriendRequestModel>> GetReceivedFriendRequest(string email)
        {
            return await _repository.GetReceivedFriendRequestByEmail(email);
        }

        public async Task<List<FriendRequestModel>> GetSendFriendRequest(string email)
        {
            return await _repository.GetSendFriendRequestByEmail(email);
        }


    }
}
