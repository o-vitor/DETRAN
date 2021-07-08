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
    public class VeiculoRepository : BaseRepository, IVeiculoRepository
    {
        public VeiculoRepository(DetranCNHDbContext Context) : base(Context) { }

        public async Task<Veiculo> Get(int id)
        {
            return await Context.Veiculo.FindAsync(id);
        }

        public async Task<Veiculo> GetByPlaca(string placa)
        {
            return await Context.Veiculo.FirstOrDefaultAsync(n => n.Placa == placa);
        }

        public async Task Insert(Veiculo entity)
        {
            await Context.Veiculo.AddAsync(entity);
            Context.SaveChanges();
        }

        public async Task<List<Veiculo>> List()
        {
            return await Context.Veiculo.ToListAsync();
        }
         
        public void Update(Veiculo entity)
        {
            Context.Veiculo.Update(entity);
            Context.SaveChanges();
        }
        public void Delete(Veiculo entity)
        {
            Context.Veiculo.Remove(entity);
            Context.SaveChanges();
        }
    }
}
