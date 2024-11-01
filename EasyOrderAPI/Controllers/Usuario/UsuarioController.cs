using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Persistencia.Service;
using System.Security.Cryptography;
using Persistencia.Interfaces;
using Persistencia.Dto;

namespace EasyOrderAPI.Controllers.Usuario
{
    [ApiController]
    [EnableCors]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly PasswordHash _passwordHash = new PasswordHash(SHA512.Create());

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException();
        }


        // TODO: Será necessário fazer uma verificação se o usuário é existente quando for fazer um novo registro, caso for, será retornado um ERRO.
        [HttpPost]
        [Route("api/registrarUsuario")]
        public IActionResult RegistrarUsuario([FromBody] UsuarioDTO usuarioDto)
        {
            // TODO: Será aplicado aqui o conceito de Service;

            string passwordEncrypted = _passwordHash.CriptografarSenha(usuarioDto.SenhaHash);
            UsuarioDTO usuarioCriptografado = new UsuarioDTO
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                DataNascimento = usuarioDto.DataNascimento,
                SenhaHash = passwordEncrypted
            };

            bool usuarioAdicionado = _usuarioRepository.Add(usuarioCriptografado);

            if (!usuarioAdicionado)
                return BadRequest("Já existe um usuário com esse email cadastrado.");

            return Ok();
        }

        [HttpPost]
        [Route("api/LoginUsuario")]
        public IActionResult Login([FromBody] UsuarioDTO usuarioDto)
        {
            // TODO: Será aplicado aqui o conceito de Service;
            string passwordEncrypted = _passwordHash.CriptografarSenha(usuarioDto.SenhaHash);

            UsuarioDTO usuarioDescriptografado = new UsuarioDTO
            {
                Email = usuarioDto.Email,
                SenhaHash = passwordEncrypted
            };
            // TODO: Colocar uma maneira de criar um Object Generic para passar os dados;

            bool usuarioLogado = _usuarioRepository.Logar(usuarioDescriptografado);

            if (!usuarioLogado)
            {
                return BadRequest("Email e/ou senha estão incorretos.");
            }
            // TODO: Entender a lógica que será utilizada aqui para fazer o Login, será necessário utilizar o repository?
            // Talvez não seja necessário, pois o Repository é utilizado apenas para fazer um CRUD no banco de dados;

            return Ok();
        }

        [HttpGet]
        [Route("api/pegarListaUsuario")]
        public IActionResult Get()
        {
            var usuario = _usuarioRepository.Get();

            return Ok(usuario);
        }
    }
}
