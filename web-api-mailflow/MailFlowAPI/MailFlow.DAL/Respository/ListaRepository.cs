using MailFlow.BE.Models;
using MailFlow.DAL.Context;
using MailFlow.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.DAL.Respository
{
    public class ListaRepository : GenericRepository<Lista>, IListaRespository
    {
        public ListaRepository(DataContext context) : base(context)
        {
            
        }

        public async Task<Lista?> GetWithContacts(Expression<Func<Lista, bool>> expression)
        {
            try
            {
                return await _context.Lista.Include(x=> x.Contactos).FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<int> HasReferenceAsync(string id)
        {
            try
            {
                var listaId = int.Parse(id);
                var count =  _context.Campania.CountAsync(c => c.ListaId == listaId);
                return count;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
