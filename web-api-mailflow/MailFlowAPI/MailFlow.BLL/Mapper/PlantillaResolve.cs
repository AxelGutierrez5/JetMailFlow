using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MailFlow.BE.Models;
using MailFlow.BLL.DTOs;
using MailFlow.DAL.Interfaces;

namespace MailFlow.BLL.Mapper
{
    public class PlantillaResolve : IValueResolver<Plantilla, PlantillaResponse, string>
    {
        private IPlantillaRepository _plantillaRepository;

        public PlantillaResolve(IPlantillaRepository plantillaRepository)
        {
            _plantillaRepository = plantillaRepository;

        }
        public string Resolve(Plantilla source, PlantillaResponse destination, string destMember, ResolutionContext context)
        {
            var usuario = _plantillaRepository.GetAsync(usuario => usuario.UsuarioId == source.UsuarioId).Result ?? throw new Exception("Error al mapear la propiedad usuario creador");
            return usuario != null ? usuario.Nombre : string.Empty;

        }
    }
}
