using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Persistencia.Service;
using System.Security.Cryptography;
using Persistencia.Interfaces;
using Persistencia.Dto;
using Core;
using EasyOrderAPI.Service.Usuario;
using EasyOrderAPI.Service;
using AutoMapper;

namespace EasyOrderAPI.Controllers.Usuario
{
    [ApiController]
    [EnableCors]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly PasswordHash _passwordHash = new PasswordHash(SHA512.Create());
        private readonly UsuarioService _usuarioService;
        private readonly Token _token;

        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException();
            _usuarioService = new UsuarioService(_usuarioRepository);
            _token = new Token();
        }


        // TODO: Será necessário fazer uma verificação se o usuário é existente quando for fazer um novo registro, caso for, será retornado um ERRO.
        [HttpPost]
        [Route("api/RegistrarUsuario")]
        public IActionResult RegistrarUsuario([FromBody] UsuarioDTO usuarioDto)
        {
            // TODO: Será aplicado aqui o conceito de Service;
            Validation validarRegistroUsuario = new Validation();
            string errorMensagem = string.Empty;
            validarRegistroUsuario = _usuarioService.ValidarRegistrarUsuario(validarRegistroUsuario, usuarioDto);

            if (validarRegistroUsuario.Validated)
            {
                string passwordEncrypted = _passwordHash.CriptografarSenha(usuarioDto.Senha);

                UsuarioDTO usuarioCriptografado = new UsuarioDTO
                {
                    Nome = usuarioDto.Nome,
                    Email = usuarioDto.Email,
                    DataNascimento = usuarioDto.DataNascimento,
                    Senha = passwordEncrypted
                };

                _usuarioRepository.Add(usuarioCriptografado);

                return Created();
            }

            foreach (ValidationMessage inconsistences in validarRegistroUsuario.Inconsistences)
            {
                errorMensagem += inconsistences.ToString() + "\n";
            }
            
            return BadRequest(errorMensagem);
        }

        [HttpPost]
        [Route("api/LoginUsuario")]
        public IActionResult Login([FromBody] UsuarioDTO usuarioDto)
        {
            Validation validarLoginUsuario = new Validation();
            string errorMensagem = string.Empty;
            validarLoginUsuario = _usuarioService.ValidarLoginUsuario(validarLoginUsuario, usuarioDto);

            if (validarLoginUsuario.Validated)
            {
                string passwordEncrypted = _passwordHash.CriptografarSenha(usuarioDto.Senha);

                UsuarioDTO usuarioCriptografado = new()
                {
                    Email = usuarioDto.Email,
                    Senha = passwordEncrypted
                };

                Validation validarParaGeracaoToken = new Validation();
                validarParaGeracaoToken = _usuarioService.ValidarParaGeracaoToken(validarParaGeracaoToken, usuarioCriptografado);

                if (validarParaGeracaoToken.Validated)
                {
                    Persistencia.Models.Usuario usuario = _usuarioRepository.GetUsuario(usuarioDto);
                    string token = _token.GerarToken(usuario);

                    return Ok(token);
                }

                foreach (ValidationMessage inconsistences in validarParaGeracaoToken.Inconsistences)
                {
                    errorMensagem += inconsistences.ToString() + "\n";
                }

                return NotFound("Usuário não foi encontrado. Erro: " + errorMensagem);
            }

            foreach (ValidationMessage inconsistences in validarLoginUsuario.Inconsistences)
            {
                errorMensagem += inconsistences.ToString() + "\n";
            }

            return BadRequest("Verifique os dados. Erro: " + errorMensagem);
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
