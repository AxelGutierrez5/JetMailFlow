using MailFlow.DAL.Context;
using MailFlow.DAL.Interfaces;
using MailFlow.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MailFlow.DAL.Respository
{
    public class ContactoRepository : GenericRepository<Contacto>, IContactoRepository
    {
        public ContactoRepository(DataContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Contacto>> GetContactosByListIdAsync(string listaId)
        {
            try
            {
                var contacto = await _context.Contactos.FirstAsync();
                var lista = await _context.Lista.Include(lista => lista.Contactos).FirstOrDefaultAsync(x => x.ListaId == int.Parse(listaId)) ?? throw new Exception("La lista no existe");
                return lista.Contactos.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }        
        }
    }
}
