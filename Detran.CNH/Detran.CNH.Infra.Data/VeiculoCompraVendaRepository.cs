using Detran.CNH.Domain.Model;
using Detran.CNH.Domain.Contract;
using Detran.CNH.Domain.Contract.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Detran.CNH.Infra.Data
{
    public class VeiculoCompraVendaRepository : BaseRepository, IVeiculoCompraVendaRepository
    {
        public VeiculoCompraVendaRepository(DetranCNHDbContext context) : base(context) { }

        public async Task<VeiculoCompraVenda> Get(int id)
        { 
            return await Context.VeiculoCompraVenda
                .Include(c => c.CondutorVendedor)
                .Include(c => c.CondutorComprador)
                .Include(c => c.Veiculo)
                .Where(c => c.ID == id)
                .FirstOrDefaultAsync();
        }

        public async Task Insert(VeiculoCompraVenda entity)
        {
            await Context.VeiculoCompraVenda.AddAsync(entity);
            Context.SaveChanges();
        }

        public async Task<List<VeiculoCompraVenda>> List()
        { 
            return await Context.VeiculoCompraVenda
                .Include(c => c.CondutorVendedor)
                .Include(c => c.CondutorComprador)
                .Include(c => c.Veiculo) 
                .ToListAsync();
        }

        public async Task<List<VeiculoCompraVenda>> ListComprasByCondutor(int condutorID)
        {
            var res = await Context.VeiculoCompraVenda
                .Include(c => c.CondutorVendedor)
                .Include(c => c.CondutorComprador)
                .Include(c => c.Veiculo)
                .Where(v => v.CondutorCompradorID == condutorID)
                .ToListAsync();

            // Distingüir por veículo
            return res.GroupBy(x => x.VeiculoID).Select(x => x.FirstOrDefault()).ToList();
        }

        public async Task<List<VeiculoCompraVenda>> ListComprasByVeiculo(int veiculoID)
        {
            var res = await Context.VeiculoCompraVenda
                .Include(c => c.CondutorVendedor)
                .Include(c => c.CondutorComprador)
                .Include(c => c.Veiculo)
                .Where(v => v.VeiculoID == veiculoID)
                .ToListAsync();

            // Distingüir por dono
            return res.GroupBy(x => x.CondutorCompradorID).Select(x => x.FirstOrDefault()).ToList();
        }
    }
}
