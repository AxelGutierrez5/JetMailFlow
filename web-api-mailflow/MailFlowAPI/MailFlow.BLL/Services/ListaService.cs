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
    public class ListaService : IListaService
    {
        private IListaRespository _listaRespository;
        private IMapper _mapper;
        private IContactoRepository _contactoRepository;

        public ListaService(IListaRespository listaRespository,  IMapper mapper, IContactoRepository contactoRepository) 
        {
            _listaRespository = listaRespository;
            _mapper = mapper;
            _contactoRepository = contactoRepository;
        }
        public async Task<ListaResponse> CreateAsync(ListaRegistroRequest request)
        {
            try
            {
                var lista = _mapper.Map<Lista>(request);
                var contactosAsociados = await _contactoRepository.FilterAsync(contacto => request.Contactos.Contains(contacto.ContactoId));

                foreach (Contacto item in contactosAsociados)
                {
                    lista.Contactos.Add(item);
                    
                }

                await _listaRespository.CreateAsync(lista);
                return _mapper.Map<ListaResponse>(lista);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var lista = await _listaRespository.GetWithContacts(x => x.ListaId == int.Parse(id))
                            ?? throw new Exception("No se encontro la lista seleccionada");


                lista.Contactos.Clear();
                await _listaRespository.DeleteAsync(lista);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ListaResponse>> GetAllAsync()
        {
            try
            {
                var listaMap = _mapper.Map<IEnumerable<ListaResponse>>(await _listaRespository.GetAllAsync());
                return listaMap;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task ModifyNameAsync(string id, string name)
        {
            try
            {
                var lista = await _listaRespository.GetAsync(x => x.ListaId == int.Parse(id))
                            ?? throw new Exception("No se encontro la lista seleccionada"); 

                lista.Nombre = name;
                await _listaRespository.UpdateAsync(lista);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
