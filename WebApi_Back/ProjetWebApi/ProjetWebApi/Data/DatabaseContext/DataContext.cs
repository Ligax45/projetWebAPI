using Microsoft.EntityFrameworkCore;
using ProjetWebApi.Data.Entities;

namespace ProjetWebApi.Data.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Profil> Profils { get; set; }
        public DbSet<Annonce> Annonces { get; set; }
    }
}
