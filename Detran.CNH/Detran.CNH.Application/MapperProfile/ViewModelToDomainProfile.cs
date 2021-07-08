using Detran.CNH.Domain.Model;
using Detran.CNH.Application.ViewModel.Request;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Detran.CNH.Application.MapperProfile
{
    public class ViewModelToDomainProfile : Profile
    { 
        public ViewModelToDomainProfile()
        {
            CreateMap<UsuarioViewModelRequest, Usuario>();
            CreateMap<VeiculoViewModelRequest, Veiculo>();
            CreateMap<CondutorViewModelRequest, Condutor>();
            CreateMap<VeiculoCompraVendaViewModelRequest, VeiculoCompraVenda>();
        } 
    }
}
