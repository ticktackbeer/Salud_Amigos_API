using Salud_Amigos.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salud_Amigos.App.Interface
{
    public interface IUserAccountService
    {

        Task<UserAccount> CreateUserAccount(string email, string token, string nickName, string name, string password, int age);
    }
}
