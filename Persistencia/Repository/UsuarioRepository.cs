using Persistencia.Models;
using Persistencia.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public Boolean Add(Usuario usuario)
        {

            //TODO: Será retirado daqui todas as validações, ele ficará única e exclusivamente com o CRUD;
            Usuario? usuarioRegistrado = _context.Usuario.Where(usuario => usuario.Email == usuario.Email).FirstOrDefault();

            if(usuarioRegistrado != null)
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public Boolean Logar(string email, string senhaHash)
        {
            Usuario? usuarioRegistrado = _context.Usuario.Where(usuarioRegistrado => usuarioRegistrado.Email == email &&
                                                                           usuarioRegistrado.SenhaHash == senhaHash).FirstOrDefault();

            if( usuarioRegistrado != null )
                return true;

            return false;
        }

        public List<Usuario> Get()
        {
            return _context.Usuario.ToList();
        }
    }
}
