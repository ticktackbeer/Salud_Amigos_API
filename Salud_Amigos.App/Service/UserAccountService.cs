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
    public class UserAccountService : IUserAccountService
    {
        private readonly IRepository _repository;
        public UserAccountService(IRepository repository)
        {
            _repository = repository;
        }



        public async Task<OneOf<UserAccountModel, Errors>> CreateUserAccount(string email, string token, string nickName, string name, string password, int age)
        {
            var user= await _repository.CreateUserAccount(email, nickName, name, password, age);
            user.MapT0(t0 => _repository.CreateToken(t0.Id, token, email).Result.MapT1(t1=> _repository.DeleteUserById(t0.Id)));
            //await _repository.CreateToken(user.Id, token, email);
            return user ;
        }

        public async Task<OneOf<List<UserAccountModel>, Errors>> GetUsersByEmail(List<string> emails)
        {
            return await _repository.GetUsersByEmail(emails);
        }

        public async Task<OneOf<List<UserAccountModel>, Errors>> GetUsersBySearchText(string searchText)
        {
            return  await _repository.GetUsersBySearchText(searchText);
        }

        public async Task<OneOf<Success, Errors>> DeleteUserById(Guid userId)
        {
            var result= await _repository.DeleteUserById(userId);
            return result;
                
        }
    }
}
