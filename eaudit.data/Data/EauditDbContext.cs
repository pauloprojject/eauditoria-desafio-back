using eaudit.data.Model;
using eaudit.data.Model.Mapeamentos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eaudit.data.Data
{
    public class EauditDbContext : DbContext
    {
        public EauditDbContext(DbContextOptions<EauditDbContext> options) : base(options) { }

        public DbSet<Locacao> Locacaos { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapeamento());
            modelBuilder.ApplyConfiguration(new FilmeMapeamento());
            modelBuilder.ApplyConfiguration(new LocacaoMapeamento());
        }
    }
}
