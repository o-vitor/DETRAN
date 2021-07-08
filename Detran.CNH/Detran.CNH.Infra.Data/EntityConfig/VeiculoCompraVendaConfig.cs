using Detran.CNH.Domain.Model;
using Detran.CNH.Domain.Contract;
using Detran.CNH.Domain.Contract.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Detran.CNH.Infra.Data.EntityConfig
{
    public class VeiculoCompraVendaConfig : IEntityTypeConfiguration<VeiculoCompraVenda>
    {
        public void Configure(EntityTypeBuilder<VeiculoCompraVenda> builder)
        {
            builder.ToTable("VeiculoCompraVenda");
            builder.HasKey(e => e.ID);

            builder.HasOne(e => e.CondutorComprador)
                   .WithMany(e => e.VeiculosCompras)
                   .HasForeignKey(e => e.CondutorCompradorID);
        }
    }
}