using Microsoft.EntityFrameworkCore;

namespace TestFinale.DataSource

{
    public class UtentiContext : DbContext
    {
        public UtentiContext() { }
        public UtentiContext(DbContextOptions<UtentiContext> options) : base(options) { }

        public DbSet<Entities.Utente> Utenti { get; set; }


    }
}

