using Detran.CNH.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Detran.CNH.Domain.Contract.Repository
{
    public interface ICondutorRepository
    {
        public Task Insert(Condutor entity);
        public void Update(Condutor entity);
        public void Delete(Condutor entity);
        public Task<List<Condutor>> List();
        public Task<Condutor> Get(int id);
        public Task<Condutor> GetByCPF(string cpf);
    }
}
