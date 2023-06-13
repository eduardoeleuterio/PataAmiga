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
        public DbSet<AbrigoPet> AbrigoPets { get;set; }
        public DbSet<Adocao> Adocoes { get; set; }
        public DbSet<Adotante> Adotantes{ get; set; }
        public DbSet<Cachorro> Cachorros { get; set; }  
        public DbSet<Coelho> Coelhoes { get; set;}
        public DbSet<Doador> Doadores { get; set;}
        public DbSet<EnderecoAdotante> enderecoAdotantes { get; set; }  
        public DbSet<Gato> Gatos { get; set; }
    }
}
