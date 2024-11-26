using AutoMapper;
using Persistencia.Dto;
using Persistencia.Models;

namespace Persistencia
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
