using Azure;
using FluentValidation;
using FluentValidation.Results;
using MailFlow.BLL.DTOs;
using MailFlow.BLL.Interfaces;
using MailFlow.BLL.Validations;
using MailFlow.UTILITY;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ApiResponse = MailFlow.BLL.DTOs.ApiResponse;


namespace MailFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService) 
        {
            _usuarioService = usuarioService;
        
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse>> Login([FromBody] LoginRequest session, IValidator<LoginRequest> loginValidator)
        {
           
            var response = new ApiResponse();
            try
            {
                var results = loginValidator.Validate(session);

                if (!results.IsValid)
                {
                    response.Value = results.Errors.Select(error => error.ErrorMessage).ToList();
                    throw new Exception("Error de validacion de datos");
                }

                LoginResult result = await _usuarioService.VerifyCredentialsAsync(session);


                switch (result)
                {
                    case LoginResult.Success:
                        response.Success = true;
                        response.Message = "Se han confirmado las credenciales";

                        return Ok(response);

                       
                    case LoginResult.Invalid:
                        response.Success = false;
                        response.Message = "El email o contraseñas son invalidos";

                        return Unauthorized(response);

                    case LoginResult.UserNotFound:
                        response.Success = false;
                        response.Message = "No esta registrado. Debe crear una cuenta";

                        return Unauthorized(response);

                    default:
                        return BadRequest("ocurrio algo inesperado en el servidor");
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse>> Registrar([FromBody] UsuarioRegistoRequest usuario, 
                                                                    IValidator<UsuarioRegistoRequest> validator)
        {   
            var response = new ApiResponse();

            try
            {
                //Si tiene al menos una validacion asincrona usa validateAsync
                var resultValidation = await validator.ValidateAsync(usuario);
                if (!resultValidation.IsValid)
                {
                    response.Value = resultValidation.Errors.Select(error => error.ErrorMessage).ToList();
                    throw new Exception("Error de validacion de datos");

                }
                response.Value = await _usuarioService.RegisterAsync(usuario);
                response.Success = true;
                response.Message = "Registrado con exito";

                return Ok(response);
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
        private string GetErrorsValidate(ValidationResult results)
        {
            string errors = "";
            results.Errors.ForEach(x => errors += x.ErrorMessage + Environment.NewLine);

            return errors;

        }

    }
}
