using Salud_Amigos.App.Interface;
using Salud_Amigos.App.Model;
using Salud_Amigos.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salud_Amigos.Storage
{
    public class Repository : IRepository
    {

        private readonly SqlContext _context;
        public Repository(SqlContext context)
        {
            _context = context;
        }

        public async Task<UserAccount> CreateUserAccount(string email, string token, string nickName, string name, string password, int age)
        {

            UserAccountEntity entity = new UserAccountEntity();
            entity.Email = email;
            entity.Token = token;
            entity.NickName = nickName;
            entity.Name = name;
            entity.Password = password;
            entity.Age = age;
            _context.UserAccount.Local.Add(entity);
            await _context.SaveChangesAsync();

            entity.Id = entity.Id;
            return entity.ToModel();
        }
    }
}
