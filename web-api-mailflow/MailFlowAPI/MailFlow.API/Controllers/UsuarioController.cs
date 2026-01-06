using Azure;
using FluentValidation;
using MailFlow.BE.DTOs;
using MailFlow.BLL.Interfaces;
using MailFlow.BLL.Validations;
using MailFlow.UTILITY;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Response = MailFlow.BE.DTOs.Response;

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

        public async Task<ActionResult<Response>> Login([FromBody] LoginRequest session, IValidator<LoginRequest> loginValidator)
        {
           
            var response = new Response();
            try
            {
                var results = loginValidator.Validate(session);

                if (!results.IsValid)
                {
                    string errors = "";

                    results.Errors.ForEach(x => errors += x.ErrorMessage + Environment.NewLine);

                    throw new Exception(errors);
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
                        return BadRequest("error inesperado");
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        public async Task<ActionResult<UsuarioResponse>> Registrar([FromBody] UsuarioRegistoRequest usuario)
        {   
            var response = new Response();

            try
            {

                return null;
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
