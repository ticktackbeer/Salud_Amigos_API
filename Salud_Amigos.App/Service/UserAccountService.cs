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



        public Task<UserAccount> CreateUserAccount(string email, string token, string nickName, string name, string password, int age)
        {
           return _repository.CreateUserAccount(email, token, nickName, name, password, age);  
        }
    }
}
