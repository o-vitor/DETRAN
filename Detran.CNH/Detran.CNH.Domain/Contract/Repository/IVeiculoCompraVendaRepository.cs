using Detran.CNH.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Detran.CNH.Domain.Contract.Repository
{
    public interface IVeiculoCompraVendaRepository
    {
        public Task Insert(VeiculoCompraVenda entity);  
        public Task<List<VeiculoCompraVenda>> List();
        public Task<VeiculoCompraVenda> Get(int id);
        public Task<List<VeiculoCompraVenda>> ListComprasByCondutor(int condutorID);
        public Task<List<VeiculoCompraVenda>> ListComprasByVeiculo(int veiculoID);
    }
}
