using Microsoft.EntityFrameworkCore;
using API_JBG_2.Models;

namespace API_JBG_2.Contexts
{
    public class SQLServerConnection : DbContext
    {

        public SQLServerConnection(DbContextOptions<SQLServerConnection> options) : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        
    }
}
