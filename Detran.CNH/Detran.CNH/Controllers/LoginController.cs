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
    public class LoginController : ControllerBase
    {
        private readonly IJWTTokenService tokenSvc;
        private readonly IUsuarioService usuarioService;
        public LoginController(IJWTTokenService tokenService, IUsuarioService usuarioService)
        {
            this.tokenSvc = tokenService;
            this.usuarioService = usuarioService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UsuarioViewModelRequest userReq)
        {
            try
            {
                var user = await usuarioService.Login(userReq);
                if (user == null)
                    return NotFound("Usuário ou senha inválido.");

                var token = tokenSvc.GenerateToken(user);
                return new OkObjectResult(new { usuario = user, token = token });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
