using MailFlow.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.DAL.Interfaces
{
    public interface IEnvioRepository : IGenericRepository<Envio>
    {
       Task<IEnumerable<Envio>> GetEnviosByCampaniaIdAsync(string campaniaId);

        Task<IEnumerable<Envio>> GetEnviosPendientesAsync(string campaniaId, int? size = null);



    }
}
