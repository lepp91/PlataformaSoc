using Microsoft.EntityFrameworkCore;
using ProyectoSOC.Models.Entity;

namespace ProyectoSOC.Data
{
    public class SocDB : DbContext
    {
        public SocDB(DbContextOptions<SocDB> options) : base(options)
        {
            
        }

        public DbSet<Usuario> Usuario => Set<Usuario>();
    }
}
