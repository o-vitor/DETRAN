using System;
using System.Collections.Generic;
using System.Text;

namespace Detran.CNH.Application.ViewModel.Response
{
    public class CondutorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CNH { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
