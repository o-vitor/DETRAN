﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Detran.CNH.Domain.Model
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
