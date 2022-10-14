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
    public interface IUserAccountService
    {

        Task<OneOf<UserAccountModel, Errors>> CreateUserAccount(string email, string token, string nickName, string name, string password, int age);
        Task<OneOf<List<UserAccountModel>, Errors>> GetUsersByEmail(List<string> emails);
        Task<OneOf<List<UserAccountModel>, Errors>> GetUsersBySearchText(string searchText);
        Task<OneOf<Success, Errors>> DeleteUserById(Guid userId);
    }
}
