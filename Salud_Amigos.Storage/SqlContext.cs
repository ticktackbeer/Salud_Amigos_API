using Microsoft.EntityFrameworkCore;
using Salud_Amigos.Storage.Entities;

namespace Salud_Amigos.Storage
{
    public class SqlContext : DbContext 
    {

        public DbSet<UserAccountEntity> UserAccount { get; set; } = null!;
        public DbSet<FriendEntity> Friend { get; set; } = null!;
        public DbSet<FriendRequestEntity> FriendRequest { get; set; } = null!;
        public DbSet<TokenEntity> Token { get; set; } = null!;

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserAccountEntity>(builder =>
            {
                builder.ToTable("User");
               // builder.HasKey(u => u.Id);
                             
            });

            modelBuilder.Entity<FriendEntity>(builder =>
            {
                builder.ToTable("Friend");
                builder.HasKey(f => f.Id);
                builder.HasOne(e => e.Token).WithOne()
                .HasPrincipalKey<FriendEntity>(x => x.UserIdFriend)
                .HasForeignKey<TokenEntity>(n => n.UserId);

                builder.HasOne(e => e.UserAccountFriend)
                .WithOne()
                .HasForeignKey<FriendEntity>(h=> h.UserIdFriend);

            });

            modelBuilder.Entity<FriendRequestEntity>(builder =>
            {
                builder.ToTable("FriendRequest");
                builder.HasKey(fr => fr.Id);

            });

            modelBuilder.Entity<TokenEntity>(builder =>
            {
                builder.ToTable("Token");
                builder.HasKey(x => x.Id);

            });

        }
    }
}
