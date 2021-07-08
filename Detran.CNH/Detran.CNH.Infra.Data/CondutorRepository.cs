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
    public class CondutorRepository : BaseRepository, ICondutorRepository
    {
        public CondutorRepository(DetranCNHDbContext context) : base(context) { }

        public void Delete(Condutor entity)
        {
            Context.Condutor.Remove(entity);
            Context.SaveChanges();
        }

        public async Task<Condutor> Get(int id)
        {
            return await Context.Condutor.FindAsync(id);
        }

        public async Task<Condutor> GetByCPF(string cpf)
        {
            return await Context.Condutor.FirstOrDefaultAsync(c => c.CPF == cpf);
        }

        public async Task Insert(Condutor entity)
        {
            await Context.Condutor.AddAsync(entity);
            Context.SaveChanges();
        }

        public async Task<List<Condutor>> List()
        {
            return await Context.Condutor.ToListAsync();
        }

        public void Update(Condutor entity)
        {
            Context.Condutor.Update(entity);
            Context.SaveChanges();
        }
    }
}
