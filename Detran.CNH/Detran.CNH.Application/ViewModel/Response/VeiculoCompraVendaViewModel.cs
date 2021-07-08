using System;
using System.Collections.Generic;
using System.Text;

namespace Detran.CNH.Application.ViewModel.Response
{
    public class VeiculoCompraVendaViewModel
    {
        public int ID { get; set; } 
        public int VeiculoID { get; set; }
        public DateTime Data { get; set; }

        public CondutorViewModel CondutorComprador { get; set; }
        public CondutorViewModel CondutorVendedor { get; set; }
        public VeiculoViewModel Veiculo { get; set; }
    }
}
