using Microsoft.EntityFrameworkCore;
using Salud_Amigos.App.Interface;
using Salud_Amigos.App.Model;
using Salud_Amigos.Storage.Entities;
using System.Xml.Linq;

namespace Salud_Amigos.Storage
{
    public class Repository : IRepository
    {

        private readonly SqlContext _context;
        public Repository(SqlContext context)
        {
            _context = context;
        }

        public async Task<FriendModel> CreateFriend(Guid userId, Guid userIdFriend, string email, string emailFriend)
        {
            FriendEntity entity = new FriendEntity();
            entity.UserId = userId;
            entity.UserIdFriend = userIdFriend;
            entity.Email = email;
            entity.EmailFriend = emailFriend;
            entity.Timestamp = new DateTimeOffset(DateTime.UtcNow);
            _context.Friend.Local.Add(entity);
            await _context.SaveChangesAsync();

            entity.Id = entity.Id;
            return entity.ToModel();
        }
        public async Task<int> CreateFriendRequest(UserAccountModel userAccount, UserAccountModel userAccountModelFriend)
        {
            FriendRequestEntity entity = new FriendRequestEntity();
            entity.RequestFromEmail = userAccount.Email;
            entity.RequestFromNickName = userAccount.NickName;
            entity.RequestFromUserId = userAccount.Id;

            entity.RequestToEmail = userAccountModelFriend.Email;
            entity.RequestToNickName = userAccountModelFriend.NickName;
            entity.RequestToUserId = userAccountModelFriend.Id;
            
            entity.Timestamp = new DateTimeOffset(DateTime.UtcNow);

            _context.FriendRequest.Local.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<TokenModel> CreateToken(Guid userId, string token, string email)
        {
            TokenEntity entity = new TokenEntity();

            entity.UserId = userId;
            entity.Email = email;
            entity.Token = token;
            entity.Timestamp = new DateTimeOffset(DateTime.Now);
            _context.Token.Add(entity);
            await _context.SaveChangesAsync();

            entity.Id = entity.Id;
            return entity.ToModel();
        }

        public async Task<UserAccountModel> CreateUserAccount(string email, string nickName, string name, string password, int age)
        {

            UserAccountEntity entity = new();
            entity.Email = email;
            entity.NickName = nickName;
            entity.Name = name;
            entity.Password = password;
            entity.Age = age;
            entity.Timestamp = new DateTimeOffset(DateTime.Now);
           
            _context.UserAccount.Local.Add(entity);
            await _context.SaveChangesAsync();

            entity.Id = entity.Id;
            return entity.ToModel();
        }

        public async Task<List<UserAccountModel>> GetUsersByEmail(List<string> emails)
        {
            
            var entity=  await  _context.UserAccount.Where(x=> emails.Contains(x.Email)).ToListAsync();
            return entity.Select(x => x.ToModel()).ToList();
        }

        public async Task<List<UserAccountModel>> GetUsersBySearchText(string searchText)
        {

            var entity = await _context.UserAccount.Where(x => x.Email.Contains(searchText)).ToListAsync();
            return entity.Select(x => x.ToModel()).ToList();
        }

        public async Task<List<FriendModel>> GetFriendsByEmail(string email)
        {

            var entity = await _context.Friend.Include(t=> t.Token).Include(x => x.UserAccountFriend).Where(x => x.Email.Equals(email)).ToListAsync();
            return entity.Select(x => x.ToModel()).ToList();
        }


    }
}
