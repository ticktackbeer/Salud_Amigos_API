using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;
using Salud_Amigos.App.Interface;
using Salud_Amigos.App.Model;
using Salud_Amigos.App.Model.Error;
using Salud_Amigos.Storage.Entities;

namespace Salud_Amigos.Storage
{
    public class Repository : IRepository
    {

        private readonly SqlContext _context;
        public Repository(SqlContext context)
        {
            _context = context;
        }

        public async Task<OneOf<Success,Errors>> CreateFriend(Guid userId, Guid userIdFriend, string email, string emailFriend, Guid friendRequestId)
        {
            FriendEntity entity = new FriendEntity();
            entity.UserId = userId;
            entity.UserIdFriend = userIdFriend;
            entity.Email = email;
            entity.EmailFriend = emailFriend;
            entity.Timestamp = new DateTimeOffset(DateTime.UtcNow);

            FriendEntity entity2 = new FriendEntity();
            entity2.UserId = userIdFriend;
            entity2.UserIdFriend = userId;
            entity2.Email = emailFriend;
            entity2.EmailFriend = email;
            entity2.Timestamp = new DateTimeOffset(DateTime.UtcNow);

            List<FriendEntity> friends = new List<FriendEntity>();
            friends.Add(entity);
            friends.Add(entity2);
            var friendEntities = await _context.Friend.Where(x => x.UserId == userId && x.UserIdFriend == userIdFriend || x.UserId == userIdFriend && x.UserIdFriend == userId).ToListAsync();
            if (friendEntities.Any())
            {
                return Errors.General(new FriendExistException());
            }
            _context.Friend.AddRange(friends);
            int savedRowsNumber = await _context.SaveChangesAsync();
            
            var deleteFriendResult = await DeleteFriendRequest(friendRequestId);
            if (savedRowsNumber != 2 )
            {
                return Errors.General(new CreateFriendException());
            }
            if(deleteFriendResult.IsT1)
            {
                return deleteFriendResult.AsT1;
            }
            return new Success();
        }
        public async Task<OneOf<Success,Errors>> CreateFriendRequest(UserAccountModel userAccount, UserAccountModel userAccountModelFriend)
        {
            FriendRequestEntity entity = new FriendRequestEntity();
            entity.RequestFromEmail = userAccount.Email;
            entity.RequestFromNickName = userAccount.NickName;
            entity.RequestFromUserId = userAccount.Id;

            entity.RequestToEmail = userAccountModelFriend.Email;
            entity.RequestToNickName = userAccountModelFriend.NickName;
            entity.RequestToUserId = userAccountModelFriend.Id;
            
            entity.Timestamp = new DateTimeOffset(DateTime.UtcNow);
            var existEntity = await  _context.FriendRequest.FirstOrDefaultAsync(x => x.RequestFromUserId == userAccount.Id && x.RequestToUserId == userAccountModelFriend.Id);
            if(existEntity is not null)
            {
                return Errors.General(new FriendRequestExistException());
            }
            _context.FriendRequest.Local.Add(entity);
            int count = await _context.SaveChangesAsync();
            if(count != 1)
            {
                return Errors.General(new CreateFriendRequestException());
            }
            return new Success();
        }

        public async Task<OneOf<TokenModel,Errors>> CreateToken(Guid userId, string token, string email)
        {
            TokenEntity entity = new TokenEntity();

            entity.UserId = userId;
            entity.Email = email;
            entity.Token = token;
            entity.Timestamp = new DateTimeOffset(DateTime.Now);
            var existEntity = await _context.Token.FirstOrDefaultAsync(x => x.Email.Equals(email));
            if(existEntity is not null)
            {
                Errors.General(new TokenExistException());
            }
            _context.Token.Add(entity);
            int count =await _context.SaveChangesAsync();
            if(count != 1)
            {
                return Errors.General(new CreateTokenException());
            }
            return entity.ToModel();
        }

        public async Task<OneOf<UserAccountModel,Errors>> CreateUserAccount(string email, string nickName, string name, string password, int age)
        {

            UserAccountEntity entity = new();
            entity.Email = email;
            entity.NickName = nickName;
            entity.Name = name;
            entity.Password = password;
            entity.Age = age;
            entity.Timestamp = new DateTimeOffset(DateTime.Now);
            var existingEntity = await _context.UserAccount.FirstOrDefaultAsync(x=> x.Email.Equals(email));
            if(existingEntity is not null)
            {
                return Errors.General(new UserAccountExistException());
            }
            _context.UserAccount.Local.Add(entity);
            int count = await _context.SaveChangesAsync();
            if(count != 1)
            {
                return Errors.General(new CreateUserAccountException());
            }
            
            return entity.ToModel();
        }

        public async Task<OneOf<List<UserAccountModel>,Errors>> GetUsersByEmail(List<string> emails)
        {
            if (!emails.Any())
            {
               return Errors.NotFound(new UserAccountNotFoundException());
            }
            var entity=  await  _context.UserAccount.Where(x=> emails.Contains(x.Email)).ToListAsync();

            if (!entity.Any())
            {
                return Errors.NotFound(new UserAccountNotFoundException());
            }
            return entity.Select(x => x.ToModel()).ToList();
        }

        public async Task<OneOf<List<UserAccountModel>,Errors>> GetUsersBySearchText(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return Errors.NotFound(new UserAccountNotFoundException());
            }
            var entity = await _context.UserAccount.Where(x => x.Email.Contains(searchText)).ToListAsync();
            return entity.Select(x => x.ToModel()).ToList();
        }

        public async Task<OneOf<Success,Errors>> DeleteUserById(Guid userId)
        {

            var entity = await _context.UserAccount.FirstOrDefaultAsync(x=>x.Id == userId);
            if(userId == default(Guid))
            {
               return Errors.NotFound(new UserAccountNotFoundException());
            }
            if(entity is null)
            {
               return Errors.NotFound(new UserAccountNotFoundException());
            }
             _context.UserAccount.Remove(entity);
            var count = await _context.SaveChangesAsync();
            if (count != 1)
            {
                return Errors.NotFound(new CreateUserAccountException());
            }
            var deleteRelation= await DeleteFriendRelationById(userId);
            if (deleteRelation.IsT1)
            {
                return Errors.General(new DeleteFriendException());
            }
            return new Success();
        }

        public async Task<OneOf<List<FriendModel>,Errors>> GetFriendsByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return Errors.NotFound(new FriendNotFoundException());
            }
            var entity = await _context.Friend.Include(t=> t.Token).Include(x => x.UserAccountFriend).Where(x => x.Email.Equals(email)).ToListAsync();
            return entity.Select(x => x.ToModel()).ToList();
        }

        public async Task<OneOf<List<FriendRequestModel>,Errors>> GetReceivedFriendRequestByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return Errors.NotFound(new FriendRequestNotFoundException());
            }
            var entity = await _context.FriendRequest.Where(x => x.RequestToEmail.Equals(email)).ToListAsync();
            return entity.Select(x => x.ToModel()).ToList();
        }

        public async Task<OneOf<List<FriendRequestModel>, Errors>> GetSendFriendRequestByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return Errors.NotFound(new FriendRequestNotFoundException());
            }
            var entity = await _context.FriendRequest.Where(x => x.RequestFromEmail.Equals(email)).ToListAsync();
            return entity.Select(x => x.ToModel()).ToList();
        }

        public async Task<OneOf<Success,Errors>> DeleteFriendRequest(Guid FriendRquestId)
        {
            if(FriendRquestId == default(Guid))
            {
                return Errors.NotFound(new FriendRequestNotFoundException());
            }
            var friendRequestEntity = await _context.FriendRequest.FirstOrDefaultAsync(x => x.Id == FriendRquestId);
            if(friendRequestEntity is null)
            {
              return Errors.NotFound(new FriendRequestNotFoundException());
            }
            
            _context.FriendRequest.Remove(friendRequestEntity);
             await _context.SaveChangesAsync();

            return new Success();
        }

        public async Task<OneOf<Success, Errors>> DeleteFriendRelationById(Guid userId)
        {

            if(userId == default(Guid))
            {
                return Errors.NotFound(new FriendNotFoundException());
            }
            
            var entities = await _context.Friend.Where(x => x.UserIdFriend == userId).ToListAsync();
            if (entities.Any())
            {
                _context.Friend.RemoveRange(entities);
                await _context.SaveChangesAsync();
                return new Success();
            }        
            
            return  new Success();
        }

        public async Task<OneOf<Success, Errors>> DeleteFriendById(Guid userId)
        {

            if (userId == default(Guid))
            {
                return Errors.NotFound(new FriendNotFoundException());
            }
            var entities = await _context.Friend.Where(x => x.UserId == userId).ToListAsync();

            if (entities.Any())
            {
                _context.RemoveRange(entities);
                await _context.SaveChangesAsync();
                return new Success();
            }
            return new Success();
        }




    }
}
