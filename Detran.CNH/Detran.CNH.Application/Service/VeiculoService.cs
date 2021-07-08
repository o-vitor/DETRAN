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
    public class VeiculoService : IVeiculoService
    {
        private readonly IMapper mapper;
        private readonly IVeiculoRepository veiculoRepository;
        public VeiculoService(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.veiculoRepository = veiculoRepository;
        }

        public async Task DeleteVeiculo(int id)
        {
            var veiculo = await veiculoRepository.Get(id);
            if (veiculo != null)
                veiculoRepository.Delete(veiculo);
        }

        public async Task<VeiculoViewModel> GetVeiculo(int id)
        {
            return mapper.Map<VeiculoViewModel>(await veiculoRepository.Get(id));
        }

        public async Task<VeiculoViewModel> GetVeiculoByPlaca(string placa)
        {
            if (!PlacaValida(placa))
            {
                throw new Exception("Placa inválida.");
            }

            return mapper.Map<VeiculoViewModel>(await veiculoRepository.GetByPlaca(placa));
        }

        public async Task InsertVeiculo(VeiculoViewModelRequest req)
        {
            if (!PlacaValida(req.Placa))
            {
                throw new Exception("Placa inválida.");
            }

            await veiculoRepository.Insert(mapper.Map<Veiculo>(req));
        }

        private bool PlacaValida(string placa)
        {
            // AAA-0000
            var regexPlaca = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]{3}\-\d{4}$");
            // AAA0A00
            var regexPlacaMercosul = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]{3}\d[a-zA-Z]{1}\d{2}$");

            if (regexPlaca.IsMatch(placa) || regexPlacaMercosul.IsMatch(placa))
                return true;

            return false;
        }

        public async Task<List<VeiculoViewModel>> ListVeiculos()
        {
            return mapper.Map<List<VeiculoViewModel>>(await veiculoRepository.List());
        }

        public async Task UpdateVeiculo(int id, VeiculoViewModelRequest model)
        {
            if (!PlacaValida(model.Placa))
            {
                throw new Exception("Placa inválida.");
            }

            var veiculo = await veiculoRepository.Get(id);
            veiculo.Placa = model.Placa;
            veiculo.Cor = model.Cor;
            veiculo.Modelo = model.Modelo;
            veiculo.AnoFabricacao = model.AnoFabricacao;
            veiculo.Marca = model.Marca;

            veiculoRepository.Update(veiculo);
        }
    }
}
