using Detran.CNH.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Detran.CNH.Domain.Contract.Repository
{
    public interface IVeiculoRepository
    {
        public Task Insert(Veiculo entity);
        public void Update(Veiculo entity);
        public void Delete(Veiculo entity);
        public Task<List<Veiculo>> List();
        public Task<Veiculo> Get(int id);
        public Task<Veiculo> GetByPlaca(string placa);
    }
}
