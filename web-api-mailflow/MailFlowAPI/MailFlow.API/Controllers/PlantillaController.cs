using MailFlow.BLL.DTOs;
using MailFlow.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace MailFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantillaController : ControllerBase
    {
        private IPlantillaService _plantillaService;

        public PlantillaController(IPlantillaService plantillaService)
        {
            _plantillaService = plantillaService;   
        }

        [HttpGet("listar")]
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            var response = new ApiResponse();
            try
            {
                // Lógica para obtener las plantillas
                response.Value = await _plantillaService.GetAllAsync();
                response.Success = true;
                response.Message = "Se obtuvo la lista com exito";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }


        [HttpPost("registrar")]
        public async Task<ActionResult<ApiResponse>> Register([FromBody] PlantillaRegistroRequest request, IValidator<PlantillaRegistroRequest> plantillaValidator)
        {
            var response = new ApiResponse();
            try
            {
                var results = await plantillaValidator.ValidateAsync(request);
                if (!results.IsValid)
                {
                    response.Value = results.Errors.Select(error => error.ErrorMessage).ToList();
                    throw new Exception("Error de validacion de datos");
                }
                var plantillaResult = await _plantillaService.RegisterAsync(request);
                response.Success = true;
                response.Message = "Se ha registrado la plantilla con exito";
                response.Value = plantillaResult;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPut("modificar/{id}")]
        public async Task<ActionResult<ApiResponse>> Update([FromBody] PlantillaModificarRequest request,string id)
        {
            var response = new ApiResponse();
            try
            {
                await _plantillaService.UpdateAsync(id, request);
                response.Success = true;
                response.Message = "Se ha modificado la plantilla con exito";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<ApiResponse>> Delete( string id)
        {
            var response = new ApiResponse();
            try
            {
                await _plantillaService.DeleteAsync(id);
                response.Success = true;
                response.Message = "Se ha eliminado la plantilla con exito";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
