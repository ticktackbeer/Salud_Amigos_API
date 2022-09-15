using Microsoft.EntityFrameworkCore;
using Salud_Amigos.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salud_Amigos.Storage
{
    public class SqlContext : DbContext 
    {

        public DbSet<UserAccountEntity> UserAccount { get; set; } = null!;
        public DbSet<FriendEntity> Friend { get; set; } = null!;
        public DbSet<FriendRequestEntity> FriendRequest { get; set; } = null!;

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
                
            });

            modelBuilder.Entity<FriendRequestEntity>(builder =>
            {
                builder.ToTable("FriendRequest");

            });

        }
    }
}
