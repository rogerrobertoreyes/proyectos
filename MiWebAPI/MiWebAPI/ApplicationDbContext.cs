using Microsoft.EntityFrameworkCore;
using MiWebAPI.Entidades;

namespace MiWebAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Personas> Personas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
