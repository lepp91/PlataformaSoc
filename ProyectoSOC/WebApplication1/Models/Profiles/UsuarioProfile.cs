using AutoMapper;
using ProyectoSOC.Models.Entity;
using ProyectoSOC.Models.ViewModels;

namespace ProyectoSOC.Models.Profiles
{
    public class UsuarioProfile : Profile
    {     

        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>()
            .ForMember(u => u.Usuario, ex => ex.MapFrom(u => u.UsuarioUsuario))
                    .ForMember(u => u.Nombre, ex => ex.MapFrom(u => u.UsuarioNombre))
                    .ForMember(u => u.Apellido, ex => ex.MapFrom(u => u.UsuarioApellido))
                    .ForMember(u => u.Correo, ex => ex.MapFrom(u => u.UsuarioCorreo))
                    .ForMember(u => u.Password, ex => ex.MapFrom(u => u.UsuarioPassword))
                    .ReverseMap();
        }
        
    }
}
