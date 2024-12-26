using API_JBG.Models;
using Microsoft.EntityFrameworkCore;

namespace API_JBG.Contexts
{
    public class ConexionSQLServer : DbContext
    {
        public ConexionSQLServer(DbContextOptions<ConexionSQLServer> options) : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
