using Detran.CNH.Domain.Model;
using Detran.CNH.Domain.Contract;
using Detran.CNH.Domain.Contract.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Detran.CNH.Infra.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DetranCNHDbContext _context;
        public UsuarioRepository(DetranCNHDbContext context)
        {
            this._context = context;
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuario.FirstOrDefault(u => u.Email.Equals(email) && u.Senha.Equals(senha));
        }
    }
}
