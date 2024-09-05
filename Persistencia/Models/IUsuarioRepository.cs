using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Models
{
    public interface IUsuarioRepository
    {
        Boolean Add(Usuario usuario);
        Boolean Logar(string email, string senhaHash);
        List<Usuario> Get();
    }
}
