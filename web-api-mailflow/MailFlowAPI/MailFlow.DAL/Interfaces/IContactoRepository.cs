using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailFlow.BE.Models;


namespace MailFlow.DAL.Interfaces
{
    public interface IContactoRepository : IGenericRepository<Contacto>
    {
        Task<IEnumerable<Contacto>> GetContactosByListIdAsync(string listaId);
    }
}
