using Microsoft.EntityFrameworkCore;
using SaveInformationAPI.Models;

namespace SaveInformationAPI
{
    public class APIDBContext (DbContextOptions<APIDBContext> options) : DbContext(options)
    {
        DbSet<Cancha> Cancha { get; set; }
        DbSet<Complejo> Complejo { get; set; }
        DbSet<Reserva> Reserva { get; set; }
        DbSet<Usuario> Usuario { get; set; }
    }
}
