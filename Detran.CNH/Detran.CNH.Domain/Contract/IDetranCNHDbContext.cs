using Detran.CNH.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Detran.CNH.Domain.Contract
{
    public interface IDetranCNHDbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Condutor> Condutor { get; set; }
        public DbSet<VeiculoCompraVenda> VeiculoCompraVenda { get; set; } 
    }
}
