using Azure;
using Azure.Core;
using FluentValidation;
using MailFlow.BLL.DTOs;
using MailFlow.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MailFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private IContactoService _contactoService;


        public ContactoController(IContactoService contactoService)
        {
            _contactoService = contactoService;

        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<ContactoResponse>>> GetAll()
        {
            var response = new ApiResponse();
            try
            {
                response.Value = await _contactoService.GetAllAsync();
                response.Success = false;
                response.Message = "Exito";

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
        public async Task<ActionResult<ApiResponse>> Registrar([FromBody] ContactoRegistroRequest request, IValidator<ContactoRegistroRequest> contactoValidator)
        {
            var response = new ApiResponse();
            try
            {
                var results = await contactoValidator.ValidateAsync(request);

                if (!results.IsValid)
                {
                    response.Value = results.Errors.Select(error => error.ErrorMessage).ToList();
                    throw new Exception("Error de validacion de datos");
                }


                var contactoResult = await _contactoService.RegisterAsync(request);

                response.Success = false;
                response.Message = "Se ha registrado el contacto con exito";
                response.Value = contactoResult;

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
        public async Task<ActionResult<ApiResponse>> Modificar([FromBody] ContactoModificarRequest request, string id)
        {
            var response = new ApiResponse();
            try
            {
                await _contactoService.UpdateAsync(request, id);
                response.Success = true;
                response.Message = "El contacto fue modificado con exito";

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
        public async Task<ActionResult<ApiResponse>> Eliminar (string id)
        {
            var response = new ApiResponse();
            try
            {
                await _contactoService.DeleteAsync(id);
                response.Success = true;
                response.Message = "El contacto fue eliminado con exito";

                return Ok(response);
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpGet("filtrar/{valor}")]
        public async Task<ActionResult<ApiResponse>> Filtrar(string valor)
        {
            var response = new ApiResponse();
            try
            {
                response.Value = await _contactoService.FilterAsync(valor);
                response.Success = false;
                response.Message = "Exito";

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
