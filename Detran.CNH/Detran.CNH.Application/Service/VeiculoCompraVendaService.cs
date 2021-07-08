using Detran.CNH.Application.Contract;
using Detran.CNH.Application.ViewModel.Request;
using Detran.CNH.Application.ViewModel.Response;
using Detran.CNH.Domain.Model;
using Detran.CNH.Domain.Contract.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Detran.CNH.Application.Service
{
    public class VeiculoCompraVendaService : IVeiculoCompraVendaService
    {
        private IMapper mapper;
        private readonly IVeiculoCompraVendaRepository veiculoCompraVendaRepository;
        public VeiculoCompraVendaService(IMapper mapper, IVeiculoCompraVendaRepository veiculoCompraVendaRepository)
        {
            this.mapper = mapper;
            this.veiculoCompraVendaRepository = veiculoCompraVendaRepository;
        }

        public async Task AddVeiculoCompraVenda(VeiculoCompraVendaViewModelRequest model)
        {
            if (model.CondutorCompradorID == model.CondutorVendedorID)
            {
                throw new Exception("Vendedor e Comprador devem ser diferentes.");
            }

            await veiculoCompraVendaRepository.Insert(mapper.Map<VeiculoCompraVenda>(model));
        }

        public async Task<VeiculoCompraVendaViewModel> GetVeiculoCompraVenda(int id)
        {
            return mapper.Map<VeiculoCompraVendaViewModel>(await veiculoCompraVendaRepository.Get(id));
        }

        public async Task<List<VeiculoCompraVendaViewModel>> ListVeiculoComprasVendas()
        {
            return mapper.Map<List<VeiculoCompraVendaViewModel>>(await veiculoCompraVendaRepository.List());
        }

        public async Task<List<VeiculoCompraVendaViewModel>> ListComprasByCondutor(int condutorID)
        {
            return mapper.Map<List<VeiculoCompraVendaViewModel>>(await veiculoCompraVendaRepository.ListComprasByCondutor(condutorID));
        }

        public async Task<List<VeiculoCompraVendaViewModel>> ListComprasByVeiculo(int veiculoID)
        {
            return mapper.Map<List<VeiculoCompraVendaViewModel>>(await veiculoCompraVendaRepository.ListComprasByVeiculo(veiculoID));
        }
    }
}
