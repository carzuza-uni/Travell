using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class TravellContext: DbContext
    {
        public TravellContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Pasajero> Pasajeros { get; set; }
        public DbSet<Tiquete> Tiquetes { get; set; }

    }
}