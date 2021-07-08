using Detran.CNH.Application.ViewModel.Request;
using Detran.CNH.Application.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Detran.CNH.Application.Contract
{
    public interface IUsuarioService
    {
        Task<UsuarioViewModel> Login(UsuarioViewModelRequest request); 
    }
}
