using AutoMapper;
using MailFlow.BE.Models;
using MailFlow.BLL.DTOs;
using MailFlow.BLL.Interfaces;
using MailFlow.DAL;
using MailFlow.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.Services
{
    public class ConctactoService : IContactoService
    {
        private IContactoRepository _contactoRepository;
        private IMapper _mapper;

        public ConctactoService(IContactoRepository contactoRepository, IMapper mapper)
        {
            _contactoRepository = contactoRepository;
            _mapper = mapper;
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var contacto = await _contactoRepository.GetAsync(x => x.ContactoId.ToString() == id);
                if (contacto != null)
                {
                    await _contactoRepository.DeleteAsync(contacto);
                }
                else throw new Exception($"El contacto con el id: {id} no existe");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ContactoResponse>> FilterAsync(string discriminante)
        {
            try
            {

                var response = await _contactoRepository.FilterAsync(contacto => contacto.ContactoId.ToString().Contains(discriminante) ||
                                                            contacto.Nombre.Contains(discriminante) ||contacto.Apellido.Contains(discriminante) || contacto.Estado.Contains(discriminante) 
                                                            || contacto.Email.Contains(discriminante)) ?? throw new Exception("La lista no existe");

                return _mapper.Map<IEnumerable<ContactoResponse>>(response);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ContactoResponse>> GetAllAsync()
        {
            try
            {
                var listaMapeada = _mapper.Map<IEnumerable<ContactoResponse>>(await _contactoRepository.GetAllAsync());
                return listaMapeada;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task ImportCSVAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ContactoResponse> RegisterAsync(ContactoRegistroRequest request)
        {
            try
            {
                var contacto = _mapper.Map<ContactoRegistroRequest, Contacto>(request);
                await _contactoRepository.CreateAsync(contacto);
                return _mapper.Map<Contacto, ContactoResponse>(contacto);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task UpdateAsync(ContactoModificarRequest request, string id)
        {
            try
            {
                var contacto = await _contactoRepository.GetAsync(x => x.ContactoId == int.Parse(id));

                if (contacto != null)
                {
                    var contactoModificado = _mapper.Map<ContactoModificarRequest, Contacto>(request,contacto);
                    await _contactoRepository.UpdateAsync(contactoModificado);

                }
                else { throw new Exception($"El contacto con el id: {id} no existe"); }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
