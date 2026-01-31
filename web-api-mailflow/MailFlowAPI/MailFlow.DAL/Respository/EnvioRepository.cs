using MailFlow.BE.Models;
using MailFlow.DAL.Context;
using MailFlow.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.DAL.Respository
{
    public class EnvioRepository : GenericRepository<Envio>, IEnvioRepository
    {
        public EnvioRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Envio>> GetEnviosByCampaniaIdAsync(string campaniaId)
        {
            try
            {
                return await _context.Envios.Include(envio => envio.Contacto)
                   .Where(envio => envio.CampaniaId == int.Parse(campaniaId)).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Envio>> GetEnviosPendientesAsync(string campaniaId ,int? size = null)
        {
            try
            {
                
                var query = _context.Envios
                    .Include(envio => envio.Contacto)
                    .Where(envio => envio.CampaniaId == int.Parse(campaniaId) && envio.Estado == "Pendiente");

                if (size.HasValue && size.Value > 0)
                {
                    query = query.Take(size.Value);
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
