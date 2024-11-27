using Persistencia.Interfaces;
using Persistencia.Models;
using Persistencia.Dto;
using AutoMapper;

namespace Persistencia.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        private readonly IMapper _mapper;
        public UsuarioRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void Add(UsuarioDTO usuarioDto)
        {
            Persistencia.Models.Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario GetUsuario(UsuarioDTO usuarioDTO) 
        {
            return _context.Usuario.Where(usuario => usuario.Email == usuarioDTO.Email).First();
        }

        public UsuarioDTO GetUsuario(int id) {
            Usuario? usuario = _context.Usuario.Where(usuario => usuario.Id == id).FirstOrDefault();
            UsuarioDTO usuarioDTO = null;
            
            if (usuario is not null)
                usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            
            return usuarioDTO;
        }


        public Boolean VerificarExistenciaUsuario(UsuarioDTO usuarioDto)
        {
            return _context.Usuario.Any(usuario => usuario.Email == usuarioDto.Email);
        }

        public Boolean VerificarLoginUsuario(UsuarioDTO usuarioDto)
        {
            return _context.Usuario.Any(usuario => usuario.Email == usuarioDto.Email &&
                                                   usuario.Senha == usuarioDto.Senha);
        }

        public List<Usuario> Get()
        {
            return _context.Usuario.ToList();
        }
    }
}
