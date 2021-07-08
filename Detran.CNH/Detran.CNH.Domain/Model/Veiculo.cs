using System;
using System.Collections.Generic;
using System.Text;

namespace Detran.CNH.Domain.Model
{
    public class Veiculo
    {
        public int ID { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public int AnoFabricacao { get; set; }
    }
}
