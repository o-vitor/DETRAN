using System;
using System.Collections.Generic;
using System.Text;

namespace Detran.CNH.Application.ViewModel.Request
{
    public class VeiculoCompraVendaViewModelRequest
    { 
        public int CondutorCompradorID { get; set; }
        public int? CondutorVendedorID { get; set; }
        public int VeiculoID { get; set; }
        public DateTime Data { get; set; }
    }
}
