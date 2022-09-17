namespace Salud_Amigos.App.Model
{
    public record UserAccountModel
    {


        public UserAccountModel(Guid id, string email, string nickName, string name, string password, int age )
        {
            Id = id;
            Email = email;
            NickName = nickName;
            Name = name;
            Password = password;
            Age = age;
        }

        public Guid Id { get; }
        public string Email { get; }
        public string NickName { get; }
        public string Name { get; }
        public string Password { get; }
        public int Age { get; }


        public static UserAccountModel EmptyModel()
        {
            return new UserAccountModel(Guid.Empty,string.Empty, string.Empty, string.Empty, string.Empty, default);
        }
    }
}
