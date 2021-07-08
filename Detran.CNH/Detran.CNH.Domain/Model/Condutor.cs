using System;
using System.Collections.Generic;

namespace Detran.CNH.Domain.Model
{
    public class Condutor
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CNH { get; set; }
        public DateTime DataNascimento { get; set; }

        public List<VeiculoCompraVenda> VeiculosCompras { get; set; }
    }
}
