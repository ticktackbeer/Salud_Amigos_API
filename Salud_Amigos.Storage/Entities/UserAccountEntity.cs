using Salud_Amigos.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salud_Amigos.Storage.Entities
{
    public class UserAccountEntity
    {

        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Age { get; set; }


        public UserAccount ToModel()
        {

          return new UserAccount(
                Id,
                Email,
                Token,
                NickName,
                Name,
                Password,
                Age);

        }

    }
}
