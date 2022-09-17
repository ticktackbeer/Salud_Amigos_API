using Salud_Amigos.App.Interface;
using Salud_Amigos.App.Model;
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



        public async Task<UserAccountModel> CreateUserAccount(string email, string token, string nickName, string name, string password, int age)
        {
            var user= await _repository.CreateUserAccount(email, nickName, name, password, age);
            await _repository.CreateToken(user.Id, token, email);
            return user ;
        }

        public Task<List<UserAccountModel>> GetUsersByEmail(List<string> emails)
        {
            return _repository.GetUsersByEmail(emails);
        }

        public Task<List<UserAccountModel>> GetUsersBySearchText(string searchText)
        {
            return _repository.GetUsersBySearchText(searchText);
        }
    }
}
