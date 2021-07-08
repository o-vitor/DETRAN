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
    public class CondutorController : ControllerBase
    {

        private readonly ICondutorService condutorService;
        public CondutorController(ICondutorService condutorService)
        {
            this.condutorService = condutorService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await condutorService.ListCondutores();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CondutorViewModelRequest model)
        {
            try
            {
                await condutorService.InsertCondutor(model);
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
            var result = await condutorService.GetCondutor(id);
            return Ok(result);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetByCPF(string cpf)
        {
            try
            {
                var result = await condutorService.GetCondutorByCPF(cpf);
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
        public async Task<IActionResult> AlterCondutor(int id, [FromBody] CondutorViewModelRequest model)
        {
            try
            {
                await condutorService.UpdateCondutor(id, model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondutor(int id)
        {
            await condutorService.DeleteCondutor(id);
            return Ok();
        }
    }
}
