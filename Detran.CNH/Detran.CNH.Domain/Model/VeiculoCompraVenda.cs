using System;
using System.Collections.Generic;
using System.Text;

namespace Detran.CNH.Domain.Model
{
    public class VeiculoCompraVenda
    {
        public int ID { get; set; }
        public int? CondutorVendedorID { get; set; }
        public int CondutorCompradorID { get; set; }
        public int VeiculoID { get; set; }
        public DateTime Data { get; set; }

        public Condutor CondutorVendedor { get; set; }
        public Condutor CondutorComprador { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}