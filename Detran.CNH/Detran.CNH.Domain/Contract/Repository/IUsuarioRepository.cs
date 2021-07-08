using Detran.CNH.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Detran.CNH.Domain.Contract.Repository
{
    public interface IUsuarioRepository
    { 
        public Usuario Login(string email, string senha);
    }
}
