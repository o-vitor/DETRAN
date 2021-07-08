using Detran.CNH.Application.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Detran.CNH.Application.Contract
{
    public interface IJWTTokenService
    {
        public string GenerateToken(UsuarioViewModel usuario);
    }
}
