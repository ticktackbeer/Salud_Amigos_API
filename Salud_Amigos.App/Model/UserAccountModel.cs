namespace Salud_Amigos.App.Model
{
    public record UserAccountModel
    {


        public UserAccountModel(Guid id, string email, string token, string nickName, string name, string password, int age )
        {
            Id = id;
            Email = email;
            Token = token;
            NickName = nickName;
            Name = name;
            Password = password;
            Age = age;
        }

        public Guid Id { get; }
        public string Email { get; }
        public string Token { get; init; }
        public string NickName { get; }
        public string Name { get; }
        public string Password { get; }
        public int Age { get; }
    }
}
