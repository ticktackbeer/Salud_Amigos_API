using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Salud_Amigos.App.Model
{
    public record SingleUserAccountModelDto
    {


        public SingleUserAccountModelDto(Guid userId, string email, string nickName )
        {
            UserId = userId;
            Email = email;
            NickName = nickName;
           
        }

        public Guid UserId { get; init; } = default(Guid);
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string Email { get; init; } = string.Empty;
        public string NickName { get; init; } = string.Empty;

        public static List<SingleUserAccountModelDto> ToModel( List<UserAccountModel> userAccountModel)
        {
           return userAccountModel.ConvertAll(ToModel);
        }

        public static SingleUserAccountModelDto ToModel(UserAccountModel model)
        {
            return new SingleUserAccountModelDto(model.Id, model.Email, model.NickName);
        }

    }
}
