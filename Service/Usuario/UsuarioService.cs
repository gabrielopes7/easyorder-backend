namespace Service.UsuarioService
{
    // TODO: Criar as Service para ser usado para Validar o Usuário, tanto Login; Registros e outros;
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Validation ValidarRegistrarUsuario(Validation validation, UsuarioDTO usuarioDTO)
        {
            if (String.IsNullOrEmpty(usuarioDTO.Nome))
                validation.AddInconsistence(new ValidationMessage(1, "O Nome do Usuário não pode ser nulo."));

            if (String.IsNullOrEmpty(usuarioDTO.Email))
                validation.AddInconsistence(new ValidationMessage(1, "O Email do Usuário não pode ser nulo."));

            if (String.IsNullOrEmpty(usuarioDTO.Senha))
                validation.AddInconsistence(new ValidationMessage(1, "A Senha do Usuário não pode ser nula."));

            if ()

                return validation;
        }
    }
}
