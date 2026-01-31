using AutoMapper;
using Hangfire;
using MailFlow.BE.Models;
using MailFlow.BLL.DTOs;
using MailFlow.BLL.Interfaces;
using MailFlow.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.Services
{
    public class CampaniaService : ICampaniaService
    {
        private ICampaniaRepository _campaniaRepository;
        private IEnvioRepository _envioRepository;
        private IContactoRepository _contactoRepository;
        private IMapper _mapper;
        private IMailService _mailService;
        private IBackgroundJobClient _backgroundJobClient;

        public CampaniaService(ICampaniaRepository campaniaRepository, 
                                IEnvioRepository envioRepository,
                                IContactoRepository contactoRepository,
                                IMapper mapper, IMailService mailService, IBackgroundJobClient backgroundJobClient)
        { 
            _backgroundJobClient = backgroundJobClient;
            _mailService = mailService;
            _mapper = mapper;
            _campaniaRepository = campaniaRepository;   
            _envioRepository = envioRepository;
            _contactoRepository = contactoRepository;
        }

        public async Task<CampaniaResponse> RegisterAsync(CampaniaRegistroRequest request)
        {
            try
            {
                var campania = _mapper.Map<Campania>(request);
                await _campaniaRepository.CreateAsync(campania);


                var contactoLista = await _contactoRepository.GetContactosByListIdAsync(request.ListaId.ToString());
                

                foreach (Contacto contacto in contactoLista)
                {
                    await _envioRepository.CreateAsync(new Envio()
                    {

                        CampaniaId = campania.CampaniaId,
                        ContactoId = contacto.ContactoId,
                        Estado = "Pendiente"
                    });
                    
                }

                _backgroundJobClient.Schedule(() => StartCampaign(campania.CampaniaId.ToString()),request.FechaProgramada);
                return _mapper.Map<CampaniaResponse>(campania);

            }
            catch (Exception ex)
            {

                throw;
            }
        }




        public async Task StartCampaign(string campaignId)
        {
            try
            {
                var campania = await _campaniaRepository.GetWithAssociations(campania => campania.CampaniaId == int.Parse(campaignId)) 
                                ?? throw new Exception("La campanaña seleccionada no existe");

                var enviosPorProcesar = await  _envioRepository.GetEnviosPendientesAsync(campaignId,50);

                foreach (Envio envio in enviosPorProcesar)
                {
                    try
                    {
                        await _mailService.SendEmail(envio.Contacto.Email, campania.Nombre, campania.Plantilla.ContenidoHtml);
                        envio.Estado = "Enviado";
                        envio.FechaEnvio = DateTime.UtcNow;
                    }
                    catch (Exception ex)
                    {
                        envio.Estado = "Error";

                    }

                }
                await _envioRepository.SaveChangesAsync();


                var enviosPendientesTotal = await _envioRepository.GetEnviosPendientesAsync(campaignId);
                if (enviosPendientesTotal.Count() > 0)
                {
                    _backgroundJobClient.Enqueue(() => StartCampaign(campaignId));
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
