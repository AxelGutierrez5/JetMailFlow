using MailFlow.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.DAL.Interfaces
{
    public interface IPlantillaRepository : IGenericRepository<Plantilla> 
    {
        Task<int> HasReferenceAsync(string id);
    }
}
