using KingsLeague.Models;
using Microsoft.EntityFrameworkCore;


namespace KingsLeague.Persistencia
{
    public class OracleFIAPDbContext : DbContext
    {
        public DbSet<Times> Times { get; set; }

        public DbSet<Patrocinios> Patrocinios { get; set; }

        public DbSet<Jogos> Jogos { get; set; }

        public DbSet<Jogadores> Jogadores { get; set; }


        public OracleFIAPDbContext(DbContextOptions<OracleFIAPDbContext> options) : base(options)
        {

        }
        public DbSet<KingsLeague.Models.Tecnicos> Tecnicos { get; set; } = default!;
    }
}
