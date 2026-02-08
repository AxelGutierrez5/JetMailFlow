using Hangfire;
using MailFlow.BLL.DTOs;
using MailFlow.BLL.Interfaces;
using MailFlow.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace MailFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaniaController : ControllerBase
    {

        private ICampaniaService _campaniaService;
        private IBackgroundJobClient _backgroundJobClient;

        public CampaniaController(ICampaniaService campaniaService, IBackgroundJobClient backgroundJobClient)
        {
            _campaniaService = campaniaService;
            _backgroundJobClient = backgroundJobClient;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<ApiResponse>> Registrar([FromBody] CampaniaRegistroRequest request )
        {
            var response = new ApiResponse();
            try
            {
                await _campaniaService.RegisterAsync(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
                
            }

        }

        [HttpPost("{campaniaId}")]
        public ActionResult<ApiResponse> IniciarAhora(string campaniaId)
        {
            var response = new ApiResponse();
            try
            {

                _backgroundJobClient.Enqueue<CampaniaService>((e) => e.StartCampaign(campaniaId));
                response.Success = true;
                response.Message = "La campaña inicio su ejecucion";
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
