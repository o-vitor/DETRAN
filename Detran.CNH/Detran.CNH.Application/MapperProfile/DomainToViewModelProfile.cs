using Detran.CNH.Domain.Model;
using Detran.CNH.Application.ViewModel.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Detran.CNH.Application.MapperProfile
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Veiculo, VeiculoViewModel>();
            CreateMap<Condutor, CondutorViewModel>();
            CreateMap<VeiculoCompraVenda, VeiculoCompraVendaViewModel>();
        }
    }
}
