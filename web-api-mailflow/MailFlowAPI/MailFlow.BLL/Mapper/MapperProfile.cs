using AutoMapper;
using MailFlow.BLL.DTOs;
using MailFlow.DAL;
using MailFlow.UTILITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<UsuarioRegistoRequest, Usuario>()
                .ForMember(x => x.Creacion, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(x=> x.Password, opt => opt.MapFrom(src => Encripting.SHA256(src.Password)));
            CreateMap<Usuario, UsuarioResponse>();
            
        }

    }
}
