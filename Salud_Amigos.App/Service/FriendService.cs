using OneOf;
using OneOf.Types;
using Salud_Amigos.App.Interface;
using Salud_Amigos.App.Model;
using Salud_Amigos.App.Model.Error;
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



        public async Task<OneOf<Success,Errors>> CreateFriend(Guid userId, Guid userIdFriend, string email, string emailFriend,Guid friendRequestId)
        {
       
            var returnValue= await _repository.CreateFriend(userIdFriend, userId, emailFriend, email, friendRequestId);  
            return returnValue;
        }

        public async Task<OneOf<Success, Errors>> CreateFriendRequest(UserAccountModel userAccount, UserAccountModel userAccountModelFriend)
        {
           return await  _repository.CreateFriendRequest(userAccount, userAccountModelFriend);
        }

        public  async Task<OneOf<List<FriendModel>, Errors>> GetFriends(string email)
        {
            return await _repository.GetFriendsByEmail(email);
        }

        public async Task<OneOf<List<FriendRequestModel>, Errors>> GetReceivedFriendRequest(string email)
        {
            return await _repository.GetReceivedFriendRequestByEmail(email);
        }

        public async Task<OneOf<List<FriendRequestModel>, Errors>> GetSendFriendRequest(string email)
        {
            return await _repository.GetSendFriendRequestByEmail(email);
        }

        public async Task<OneOf<Success, Errors>> DeleteFriendById(Guid userId)
        {
            return await _repository.DeleteFriendById(userId);
        }


    }
}
