using Detran.CNH.Application.ViewModel.Request;
using Detran.CNH.Application.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Detran.CNH.Application.Contract
{
    public interface IVeiculoCompraVendaService
    {
        Task<VeiculoCompraVendaViewModel> GetVeiculoCompraVenda(int id);
        Task AddVeiculoCompraVenda(VeiculoCompraVendaViewModelRequest entity); 
        Task<List<VeiculoCompraVendaViewModel>> ListVeiculoComprasVendas();
        Task<List<VeiculoCompraVendaViewModel>> ListComprasByCondutor(int condutorID);
        Task<List<VeiculoCompraVendaViewModel>> ListComprasByVeiculo(int veiculoID);
    }
}
