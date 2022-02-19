using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccessoData.Contexto
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opciones) : base(opciones)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RegistroLlamada> RegistroLlamadas { get; set; }
    }
}
