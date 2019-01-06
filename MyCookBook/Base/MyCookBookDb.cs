using Microsoft.EntityFrameworkCore;
using mycookbook.cc.MyCookBook.User.Repository.Models;

namespace mycookbook.cc.MyCookBook.Base
{
    public class MyCookBookDb : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserTokenModel> UserTokens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./MyCookBook.db");
        }
    }
}