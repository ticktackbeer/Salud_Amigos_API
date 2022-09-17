using Microsoft.EntityFrameworkCore;
using Salud_Amigos.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
                             
            });

            modelBuilder.Entity<FriendEntity>(builder =>
            {
                builder.ToTable("Friend");
                builder.HasOne(e => e.Token)
                .WithOne().HasPrincipalKey<FriendEntity>(x=>x.UserIdFriend)
                .HasForeignKey<TokenEntity>(n => n.UserId);

                builder.HasOne(e => e.UserAccountFriend)
                .WithOne().HasPrincipalKey<FriendEntity>(x => x.UserIdFriend)
                .HasForeignKey<UserAccountEntity>(n => n.Id);

                //builder.HasOne(e => e.UserAccount)
                //.WithOne().HasPrincipalKey<FriendEntity>(x => x.UserId)
                //.HasForeignKey<UserAccountEntity>(n => n.Id);


            });

            modelBuilder.Entity<FriendRequestEntity>(builder =>
            {
                builder.ToTable("FriendRequest");

            });

            modelBuilder.Entity<TokenEntity>(builder =>
            {
                builder.ToTable("Token");
                builder.HasKey(x => x.Id);
               
                
            });

        }
    }
}
