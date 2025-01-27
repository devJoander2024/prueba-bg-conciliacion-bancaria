using Microsoft.EntityFrameworkCore;
using WebAPI_Walther_Olivo.Entities;

namespace WebAPI_Walther_Olivo.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<RegistroContable> RegistrosContables { get; set; }
        public DbSet<MovimientoBancario> MovimientosBancarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<DiscrepanciaResuelta> DiscrepanciasResueltas { get; set; }



    }
}
