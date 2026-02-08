using AutoMapper;
using MailFlow.BE.Models;
using MailFlow.BLL.DTOs;
using MailFlow.BLL.Interfaces;
using MailFlow.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.Services
{
    public class PlantillaService : IPlantillaService
    {
		private IPlantillaRepository _plantillaRepository;
		private IMapper _mapper;

		public PlantillaService(IPlantillaRepository plantillaRepository, IMapper mapper) 
		{
			_plantillaRepository = plantillaRepository;
			_mapper = mapper;
        }

        public async Task DeleteAsync(string id)
        {
			try
			{
				if(await _plantillaRepository.HasReferenceAsync(id) > 0) 
					throw new InvalidOperationException("No se puede eliminar la plantilla porque esta siendo utilizada en una campaña");

                var plantilla = await _plantillaRepository.GetAsync(x => x.PlantillaId == int.Parse(id)) 
					?? throw new Exception("No se encontro la plantilla");

				await _plantillaRepository.DeleteAsync(plantilla);
			}
			catch (Exception ex)
			{

				throw;
			}
        }

        public async Task<IEnumerable<PlantillaResponse>> GetAllAsync()
        {
			try
			{
				return _mapper.Map<IEnumerable<PlantillaResponse>>( await _plantillaRepository.GetAllAsync());

            }
			catch (Exception ex)
			{

				throw;
			}
        }

        public async Task<PlantillaResponse> RegisterAsync(PlantillaRegistroRequest request)
        {
			try
			{
				var plantilla = _mapper.Map<Plantilla>(request) ?? throw new Exception("Ocurrio un error al mapear la propiedad creador de plantilla em el objeto");
				await _plantillaRepository.CreateAsync(plantilla);

				var plantillaResponse = _mapper.Map<PlantillaResponse>(plantilla);
				return plantillaResponse;

			}
			catch (Exception ex)
			{

				throw;
			}
        }

        public async Task UpdateAsync(string id, PlantillaModificarRequest request)
        {
			try
			{
				var plantilla = await _plantillaRepository.GetAsync(e => e.PlantillaId == int.Parse(id)); 

				if (plantilla == null) throw new Exception("No se encontro la plantilla solicitada");

				_mapper.Map(request, plantilla);
				await _plantillaRepository.SaveChangesAsync();
            }
			catch (Exception ex)
			{

				throw;
			}
        }




    }
}
