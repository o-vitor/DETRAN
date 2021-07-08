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
    public class VeiculoController : ControllerBase
    {
        
        private readonly IVeiculoService veiculoService;
        public VeiculoController(IVeiculoService veiculoService)
        { 
            this.veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await veiculoService.ListVeiculos();
            return Ok(result);
        }

        [HttpPost] 
        public async Task<IActionResult> Insert([FromBody] VeiculoViewModelRequest model)
        { 
            try
            {
                await veiculoService.InsertVeiculo(model);
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
            var result = await veiculoService.GetVeiculo(id);
            return Ok(result);
        }

        [HttpGet("placa/{placa}")]
        public async Task<IActionResult> GetByPlaca(string placa)
        {
            try
            {
                var result = await veiculoService.GetVeiculoByPlaca(placa);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterVeiculo(int id, [FromBody] VeiculoViewModelRequest model)
        {
            try
            {
                await veiculoService.UpdateVeiculo(id, model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            await veiculoService.DeleteVeiculo(id);
            return Ok();
        }  
    }
}
