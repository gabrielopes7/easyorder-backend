using Persistencia.Dto;
using Core;
using Persistencia.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;


namespace EasyOrderAPI.Service.Usuario
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Core.Validation ValidarLoginUsuario(Core.Validation validation, UsuarioDTO usuarioDTO) {

            if(String.IsNullOrEmpty(usuarioDTO.Email))
                validation.AddInconsistence(new ValidationMessage(1, "O Email do Usuário não pode ser nulo."));
            
            if(String.IsNullOrEmpty(usuarioDTO.Senha))
                validation.AddInconsistence(new ValidationMessage(1, "A Senha do Usuário não pode ser nula."));

            return validation;
        }

        public Core.Validation ValidarRegistrarUsuario(Core.Validation validation, UsuarioDTO usuarioDTO)
        {
            if (String.IsNullOrEmpty(usuarioDTO.Nome))
                validation.AddInconsistence(new ValidationMessage(1, "O Nome do Usuário não pode ser nulo."));

            if(String.IsNullOrEmpty(usuarioDTO.Email))
                validation.AddInconsistence(new ValidationMessage(1, "O Email do Usuário não pode ser nulo."));

            if (String.IsNullOrEmpty(usuarioDTO.Senha))
                validation.AddInconsistence(new ValidationMessage(1, "A Senha do Usuário não pode ser nula."));

            if(_usuarioRepository.VerificarExistenciaUsuario(usuarioDTO))
                validation.AddInconsistence(new ValidationMessage(1, "Já existe um usuário cadastrado com esse email."));

            return validation;
        }

        public Core.Validation ValidarParaGeracaoToken(Core.Validation validation, UsuarioDTO usuarioCriptografado)
        {
            if(!_usuarioRepository.VerificarLoginUsuario(usuarioCriptografado))
                validation.AddInconsistence(new ValidationMessage(1, "Email e/ou senha estão incorretos."));

            return validation;
        }
    }
}
