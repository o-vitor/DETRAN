using Detran.CNH.Application.ViewModel.Request;
using Detran.CNH.Application.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Detran.CNH.Application.Contract
{
    public interface IVeiculoService
    {
        Task<VeiculoViewModel> GetVeiculo(int id);
        Task<VeiculoViewModel> GetVeiculoByPlaca(string placa);
        Task InsertVeiculo(VeiculoViewModelRequest entity);
        Task UpdateVeiculo(int id, VeiculoViewModelRequest entity);
        Task DeleteVeiculo(int id);
        Task<List<VeiculoViewModel>> ListVeiculos();
    }
}
