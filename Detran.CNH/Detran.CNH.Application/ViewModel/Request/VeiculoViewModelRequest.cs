using System;
using System.Collections.Generic;
using System.Text;

namespace Detran.CNH.Application.ViewModel.Request
{
    public class VeiculoViewModelRequest
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public int AnoFabricacao { get; set; }
    }
}
