namespace Salud_Amigos.App.Model
{
    public record FriendModel
    {


        public FriendModel(Guid id, Guid userId,Guid userIdFriend, string email, string emailFriend, TokenModel token)
        {
            Id = id;
            UserId = userId;
            UserIdFriend = userIdFriend;
            Email = email;
            EmailFriend = emailFriend;
            Token = token;
            
           
        }

        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid UserIdFriend { get; }
        public string Email { get; }
        public string EmailFriend { get; }
        public TokenModel Token { get; }
    
        
    }
}
