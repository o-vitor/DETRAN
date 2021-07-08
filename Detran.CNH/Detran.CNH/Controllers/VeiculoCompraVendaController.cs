using Detran.CNH.Domain.Model;
using Detran.CNH.Application.Contract;
using Detran.CNH.Application.ViewModel.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detran.CNH.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VeiculoCompraVendaController : ControllerBase
    {

        private readonly IVeiculoCompraVendaService veiculoCompraVendaService;
        private readonly ICondutorService condutorService;
        private readonly IVeiculoService veiculoService;
        public VeiculoCompraVendaController(IVeiculoCompraVendaService veiculoCompraVendaService
            , ICondutorService condutorService
            , IVeiculoService veiculoService)
        {
            this.veiculoCompraVendaService = veiculoCompraVendaService;
            this.condutorService = condutorService;
            this.veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await veiculoCompraVendaService.ListVeiculoComprasVendas();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] VeiculoCompraVendaViewModelRequest model)
        {
            try
            {
                await veiculoCompraVendaService.AddVeiculoCompraVenda(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await veiculoCompraVendaService.GetVeiculoCompraVenda(id);
            return Ok(result);
        }

        [HttpGet("veiculo/{placa}")]
        public async Task<IActionResult> ListComprasByVeiculo(string placa)
        { 
            try
            {
                var veiculo = await veiculoService.GetVeiculoByPlaca(placa);
                if (veiculo != null)
                {
                    var result = await veiculoCompraVendaService.ListComprasByVeiculo(veiculo.Id);
                    return Ok(result);
                }
                else
                    return NotFound("Veículo não encontrado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("condutor/{cpf}")]
        public async Task<IActionResult> ListComprasByCondutor(string cpf)
        {
            try
            {
                var condutor = await condutorService.GetCondutorByCPF(cpf);
                if (condutor != null)
                {
                    var result = await veiculoCompraVendaService.ListComprasByCondutor(condutor.Id);
                    return Ok(result);
                }
                else
                    return NotFound("Condutor não encontrado");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            } 
        }
    }
}
