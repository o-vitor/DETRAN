using Detran.CNH.Domain.Contract;
using Detran.CNH.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Detran.CNH.Infra.Data
{
    public class DetranCNHDbContext : DbContext, IDetranCNHDbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Condutor> Condutor { get; set; }
        public DbSet<VeiculoCompraVenda> VeiculoCompraVenda { get; set; } 

        public DetranCNHDbContext(DbContextOptions<DetranCNHDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntityConfig.VeiculoCompraVendaConfig());
        }
    }
}
