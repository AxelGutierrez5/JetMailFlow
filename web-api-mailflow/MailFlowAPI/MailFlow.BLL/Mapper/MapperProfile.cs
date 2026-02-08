using AutoMapper;
using MailFlow.BLL.DTOs;
using MailFlow.DAL;
using MailFlow.UTILITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailFlow.BE.Models;


namespace MailFlow.BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UsuarioRegistoRequest, Usuario>()
                .ForMember(x => x.Creacion, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.Password, opt => opt.MapFrom(src => Encripting.SHA256(src.Password)))
                .ForMember(x=> x.Rol, opt=> opt.MapFrom(src=> "Marketer"));
            CreateMap<Usuario, UsuarioResponse>().ForMember(x => x.Creacion, opt => opt.MapFrom(src => src.Creacion.ToString("dd/MM/yyyy")));


            CreateMap<Contacto, ContactoResponse>().ForMember(x => x.Creacion, opt => opt.MapFrom(src => src.Creacion.ToString("dd/MM/yyyy")));
            CreateMap<ContactoRegistroRequest, Contacto>()
                .ForMember(x => x.Creacion, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<ContactoModificarRequest, Contacto>();


            CreateMap<ListaRegistroRequest, Lista>()
                .ForMember(x => x.Creacion, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.Contactos, opt => opt.Ignore());
            CreateMap<Lista, ListaResponse>().ForMember(x=> x.Creacion, opt => opt.MapFrom(src=> src.Creacion.ToString("dd/MM/yyyy")));

            CreateMap<CampaniaRegistroRequest, Campania>()
                .ForMember(x=> x.Estado, opt => opt.MapFrom(src=> "Pendiente"))
                .ForMember(x=> x.Creacion ,opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<Campania, CampaniaResponse>();

            CreateMap<Plantilla,PlantillaResponse>()
                .ForMember(x=> x.UsuarioCreador, opt=> opt.MapFrom<PlantillaResolve>())
                .ForMember(x => x.Creacion, opt => opt.MapFrom(src => src.Creacion.ToString("dd/MM/yyyy")));
            CreateMap<PlantillaRegistroRequest, Plantilla>()
                .ForMember(x => x.Creacion, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<PlantillaModificarRequest, Plantilla>();


        }

    }
}
