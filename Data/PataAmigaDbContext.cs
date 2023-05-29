using Microsoft.EntityFrameworkCore;
using PataAmiga.Models.Domain;

namespace PataAmiga.Data
{
    public class PataAmigaDbContext : DbContext
    {
        public PataAmigaDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Ong> Ongs { get; set; }
    }
}
