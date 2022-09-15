using Salud_Amigos.App.Model;

namespace Salud_Amigos.Api.Dto
{
    public record UserAccountDto(string Email, string Token, string NickName, string Name, string Password, int Age)
    {

        public static UserAccount FromModel(UserAccount userAccount)
        {

            return userAccount;
        }



    }

    
  
}
