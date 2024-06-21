using Microsoft.EntityFrameworkCore;
using ProjetWebApi.Data.Entities;

namespace ProjetWebApi.Data.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
