using EP.Magdalena_Sima.Models.Termin;
using Microsoft.EntityFrameworkCore;

namespace EP.Magdalena_Sima.Database
{
    public class TerminDbContext : DbContext
    {
        public TerminDbContext(DbContextOptions<TerminDbContext> options) : base(options)
        {
        }

        public DbSet<TerminFields> Termini { get; set; }
    }
}