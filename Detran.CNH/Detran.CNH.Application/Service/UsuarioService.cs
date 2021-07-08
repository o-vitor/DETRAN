using Detran.CNH.Application.Contract;
using Detran.CNH.Application.ViewModel.Request;
using Detran.CNH.Application.ViewModel.Response;
using Detran.CNH.Domain.Contract.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Detran.CNH.Application.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioViewModel> Login(UsuarioViewModelRequest request)
        { 
            var usuario = usuarioRepository.Login(request.Email, request.Senha);
            return mapper.Map<UsuarioViewModel>(usuario);
        }  
    }
}
