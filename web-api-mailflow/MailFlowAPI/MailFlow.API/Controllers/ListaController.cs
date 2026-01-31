using Azure.Core;
using FluentValidation;
using MailFlow.BLL.DTOs;
using MailFlow.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MailFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaController : ControllerBase
    {
        private IListaService _listaService;
        public ListaController(IListaService listaService) 
        {
            _listaService = listaService;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<ApiResponse>> Registrar([FromBody] ListaRegistroRequest request, IValidator<ListaRegistroRequest> validator)
        {
            var response = new ApiResponse();
            try
            {
                var results = await validator.ValidateAsync(request);

                if (!results.IsValid)
                {
                    response.Value = results.Errors.Select(error => error.ErrorMessage).ToList();
                    throw new Exception("Error de validacion de datos");
                }

                var listaResponse = await _listaService.CreateAsync(request);

                response.Success = true;
                response.Message = "La lista fue creada con exito";
                response.Value = listaResponse;
                return Ok(response);
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }

        [HttpGet("listar")]
        public async Task<ActionResult<ApiResponse>> ObtenerTodos()
        {
            var response = new ApiResponse();
            try
            {

                response.Value = await _listaService.GetAllAsync();
                response.Success = true;
                response.Message = "";
                return Ok(response);
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }


        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<ApiResponse>> Eliminar(string id)
        {
            var response = new ApiResponse();
            try
            {

                await _listaService.DeleteAsync(id);
                response.Success = true;
                response.Message = "La lista fue eliminada con exito";
                return Ok(response);
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }

        [HttpPut("modificarnombre/{id}")]
        public async Task<ActionResult<ApiResponse>> ModificarNombre( string id, [FromBody] ListaModificarRequest request)
        {
            var response = new ApiResponse();
            try
            {

                await _listaService.ModifyNameAsync(id, request.Nombre);
                response.Success = true;
                response.Message = "Se modifico el nombre con exito";
                return Ok(response);
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }
    }
}
