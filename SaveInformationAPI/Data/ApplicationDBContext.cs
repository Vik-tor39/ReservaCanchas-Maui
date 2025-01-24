using Microsoft.EntityFrameworkCore;
using SaveInformationAPI.Models;

namespace SaveInformationAPI.Data
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)
    {
        public DbSet<Cancha> Cancha { get; set; }
        public DbSet<Complejo> Complejo { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
