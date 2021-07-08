using Detran.CNH.Application.Contract;
using Detran.CNH.Application.ViewModel.Response;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Detran.CNH.Application.Service
{
    public class JWTTokenService : IJWTTokenService
    {
        private IConfiguration _config;
        public JWTTokenService(IConfiguration config)
        {
            this._config = config;
        }

        public string GenerateToken(UsuarioViewModel usuario)
        {
            var key = Encoding.ASCII.GetBytes(_config.GetSection("Config")["SecKey"]);
            var handler = new JwtSecurityTokenHandler();
            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, usuario.Nome)
            };

            var descriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.Now.AddDays(1)
            };
            var token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
