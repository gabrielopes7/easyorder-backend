using Persistencia.Models;
using Persistencia.Dto;

namespace Persistencia.Interfaces
{
    public interface IUsuarioRepository
    {
        void Add(UsuarioDTO usuarioDto);
        Usuario GetUsuario(UsuarioDTO usuarioDto);
        UsuarioDTO GetUsuario(int id);
        bool VerificarExistenciaUsuario(UsuarioDTO usuarioDto);
        bool VerificarLoginUsuario(UsuarioDTO usuarioDto);
        List<Usuario> Get();
    }
}
